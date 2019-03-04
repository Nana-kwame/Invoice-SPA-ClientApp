﻿// <auto-generated />
using System;
using InvoiceSPA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InvoiceSPA.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvoiceSPA.Entities.Authority", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Approved");

                    b.Property<DateTime?>("ApprovedOn");

                    b.Property<string>("Department");

                    b.Property<long>("InvoiceId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Authorities");
                });

            modelBuilder.Entity("InvoiceSPA.Entities.Invoice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Approved");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("InvoiceNo");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<long?>("RecipientId");

                    b.Property<bool>("Status");

                    b.Property<string>("Title");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("InvoiceSPA.Entities.InvoiceItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Amount");

                    b.Property<string>("Description");

                    b.Property<long>("InvoiceId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceItems");
                });

            modelBuilder.Entity("InvoiceSPA.Entities.Recipient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<string>("RecipientNumber");

                    b.HasKey("Id");

                    b.ToTable("Recipients");
                });

            modelBuilder.Entity("InvoiceSPA.Entities.Authority", b =>
                {
                    b.HasOne("InvoiceSPA.Entities.Invoice", "Invoice")
                        .WithMany("Authorities")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InvoiceSPA.Entities.Invoice", b =>
                {
                    b.HasOne("InvoiceSPA.Entities.Recipient", "Recipient")
                        .WithMany("Invoices")
                        .HasForeignKey("RecipientId");
                });

            modelBuilder.Entity("InvoiceSPA.Entities.InvoiceItem", b =>
                {
                    b.HasOne("InvoiceSPA.Entities.Invoice", "Invoice")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
