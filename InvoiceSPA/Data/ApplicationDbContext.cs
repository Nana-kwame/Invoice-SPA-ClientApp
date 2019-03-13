// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationDbContext.cs" company="">
//   
// </copyright>
// <summary>
//   The application db context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Data
{
    using InvoiceSPA.Entities;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The application db context.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the invoices.
        /// </summary>
        public DbSet<Invoice> Invoices { get; set; }

        /// <summary>
        /// Gets or sets the invoice items.
        /// </summary>
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        /// <summary>
        /// Gets or sets the authorities.
        /// </summary>
        public DbSet<Authority> Authorities { get; set; }

        /// <summary>
        /// Gets or sets the recipients.
        /// </summary>
        public DbSet<Recipient> Recipients { get; set; }

        /// <summary>
        /// The Application User
        /// </summary>
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity filters
            modelBuilder.Entity<Invoice>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Recipient>().HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
