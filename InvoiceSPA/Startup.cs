// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA
{
    using System;
    using System.Collections.Generic;

    using InvoiceApp.Repositories;

    using InvoiceSPA.Data;
    using InvoiceSPA.Entities;
    using InvoiceSPA.Interfaces;
    using InvoiceSPA.Repositories;
    using InvoiceSPA.Services;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SpaServices.AngularCli;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Internal;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// The startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        /// <summary>
        /// The configure services.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.Configure<CookiePolicyOptions>(options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=InvoiceSPADb;Trusted_Connection=True;"));

            // services
            services.AddScoped<IRecipientRepository, RecipientRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IRecipientService, RecipientService>();
            services.AddScoped<IInvoiceItemRepository, InvoiceItemRepository>();
            services.AddScoped<IAuthorityRepository, AuthorityRepository>();
            services.AddScoped<UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        /// <param name="env">
        /// The env.
        /// </param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            InitializeDatabase(app);

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        /// <summary>
        /// The initialize database.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        private static void InitializeDatabase(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            //pupulate database on startup 

            if (!context.Recipients.Any())
            {
                var recipient = new List<Recipient>
                {
                    new Recipient
                    {
                        Name = "CloudBuilders Ghana Ltd",
                        Address = "P.O.Box TF 292, La - Accra, Ghana",
                        RecipientNumber = "RNo.001",
                        Invoices = new List<Invoice>
                        {
                            new Invoice
                            {
                                InvoiceNo = "INo.1",
                                Title = "First Job",
                                CreatedBy = "Peter Awuah",
                                CreatedOn = DateTime.Now,
                                Approved = false,
                                Status = true,
                                Authorities = new List<Authority>()
                                {
                                    new Authority
                                    {
                                        Name = "Peter Awuah",
                                        Department = "IT"
                                    }
                                },
                                InvoiceItems = new List<InvoiceItem>()
                                {
                                    new InvoiceItem()
                                    {
                                        Name = "Proof of Concept",
                                        Amount = "2000",
                                        Description = "Poof of appplication"
                                    },
                                    new InvoiceItem()
                                    {
                                        Name = "First deliverable",
                                        Amount = "2000",
                                        Description = "Delivered first application concept"
                                    },
                                    new InvoiceItem()
                                    {
                                        Name = "Final Payment",
                                        Amount = "2000",
                                        Description = "Submitted complete solution"
                                    }
                                }
                            },
                            new Invoice
                            {
                                InvoiceNo = "INo.2",
                                Title = "Second Job",
                                CreatedBy = "Peter Awuah",
                                CreatedOn = DateTime.Now,
                                Approved = false,
                                Status = true,
                                Authorities = new List<Authority>()
                                {
                                    new Authority
                                    {
                                          Name = "Peter Awuah",
                                          Department = "IT"
                                    }
                                },
                                InvoiceItems = new List<InvoiceItem>()
                                {
                                    new InvoiceItem()
                                    {
                                        Name = "Proof of Concept",
                                        Amount = "2000",
                                        Description = "Poof of appplication"
                                    },
                                    new InvoiceItem()
                                    {
                                        Name = "First deliverable",
                                        Amount = "2000",
                                        Description = "Delivered first application concept"
                                    },
                                    new InvoiceItem()
                                    {
                                        Name = "Final Payment",
                                        Amount = "2000",
                                        Description = "Submitted complete solution"
                                    }
                                }
                            },
                            new Invoice
                            {
                                InvoiceNo = "INo.3",
                                Title = "Third Job",
                                CreatedBy = "Peter Awuah",
                                CreatedOn = DateTime.Now,
                                Approved = false,
                                Status = true,
                                Authorities = new List<Authority>()
                                {
                                    new Authority
                                    {
                                        Name = "Peter Awuah",
                                        Department = "IT"
                                    }
                                },
                                InvoiceItems = new List<InvoiceItem>()
                                {
                                    new InvoiceItem()
                                    {
                                       Name = "Proof of Concept",
                                       Amount = "2000",
                                       Description = "Poof of appplication"
                                    },
                                    new InvoiceItem()
                                    {
                                       Name = "First deliverable",
                                       Amount = "2000",
                                       Description = "Delivered first application concept"
                                    },
                                    new InvoiceItem()
                                    {
                                       Name = "Final Payment",
                                       Amount = "2000",
                                       Description = "Submitted complete solution"
                                    }
                                }
                            },
                            new Invoice
                            {
                                InvoiceNo = "INo.4",
                                Title = "Fourth Job",
                                CreatedBy = "Peter Awuah",
                                CreatedOn = DateTime.Now,
                                Approved = false,
                                Status = true,
                                Authorities = new List<Authority>()
                                {
                                    new Authority
                                    {
                                        Name = "Peter Awuah",
                                        Department = "IT"
                                    }
                                },
                                InvoiceItems = new List<InvoiceItem>()
                                {
                                    new InvoiceItem()
                                    {
                                        Name = "Proof of Concept",
                                        Amount = "2000",
                                        Description = "Poof of appplication"
                                    },
                                    new InvoiceItem()
                                    {
                                        Name = "First deliverable",
                                        Amount = "2000",
                                        Description = "Delivered first application concept"
                                    },
                                    new InvoiceItem()
                                    {
                                        Name = "Final Payment",
                                        Amount = "2000",
                                        Description = "Submitted complete solution"
                                    }
                                }
                            },
                            new Invoice
                            {
                                InvoiceNo = "INo.5",
                                Title = "Fifth Job",
                                CreatedBy = "Peter Awuah",
                                CreatedOn = DateTime.Now,
                                Approved = false,
                                Status = true,
                                Authorities = new List<Authority>()
                                {
                                    new Authority
                                    {
                                        Name = "Peter Awuah",
                                        Department = "IT"
                                    }
                                },
                                InvoiceItems = new List<InvoiceItem>()
                                {
                                    new InvoiceItem()
                                    {
                                       Name = "Proof of Concept",
                                       Amount = "2000",
                                       Description = "Poof of appplication"
                                    },
                                    new InvoiceItem()
                                    {
                                       Name = "First deliverable",
                                       Amount = "2000",
                                       Description = "Delivered first application concept"
                                    },
                                    new InvoiceItem()
                                    {
                                       Name = "Final Payment",
                                       Amount = "2000",
                                       Description = "Submitted complete solution"
                                    }
                                }
                            }
                        }
                    }
                };

                context.Recipients.AddRange(recipient);
                context.SaveChanges();
            }
        }
    }
}
