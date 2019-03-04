// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The invoice repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceApp.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EFCore.BulkExtensions;

    using InvoiceSPA.Data;
    using InvoiceSPA.Entities;
    using InvoiceSPA.Interfaces;

    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc />
    /// <summary>
    /// The invoice repository.
    /// </summary>
    public class InvoiceRepository : IInvoiceRepository
    {
        /// <summary>
        /// The application db context.
        /// </summary>
        private readonly ApplicationDbContext applicationDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceRepository"/> class.
        /// </summary>
        /// <param name="applicationDbContext">
        /// The application db context.
        /// </param>
        public InvoiceRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        /// <inheritdoc />
        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="invoice">
        /// The invoice.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public void Add(Invoice invoice)
        {
            this.applicationDbContext.Invoices.Add(invoice);
        }

        /// <inheritdoc />
        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="invoice">
        /// The invoice.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public void Update(Invoice invoice)
        {
            this.applicationDbContext.Invoices.Update(invoice);
        }

        /// <inheritdoc />
        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="invoice">
        /// The invoice.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public void Remove(Invoice invoice)
        {
            this.applicationDbContext.Invoices.Remove(invoice);
        }

        /// <inheritdoc />
        /// <summary>
        /// The find by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public async Task<Invoice> FindById(string id)
        {
            return await this.applicationDbContext.Invoices
                       .Include(x => x.InvoiceItems)
                       .Include(x => x.Authorities)
                       .Include(x => x.Recipient)
                       .FirstOrDefaultAsync(x => x.InvoiceNo == id);
        }

        /// <inheritdoc />
        /// <summary>
        /// The find by creator.
        /// </summary>
        /// <param name="creator">
        /// The creator.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public async Task<List<Invoice>> FindByCreator(string creator)
        {
             return await this.applicationDbContext.Invoices
                       .Include(x => x.InvoiceItems)
                       .Include(x => x.Authorities)
                       .Include(x => x.Recipient)
                       .Where(x => x.CreatedBy.Equals(creator, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        }

        /// <summary>
        /// The get invoice count.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetInvoiceCount()
        {
            return this.applicationDbContext.Invoices.ToList().Count;
        }

        /// <inheritdoc />
        /// <summary>
        /// The save changes.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public async Task SaveChanges()
        {
            await this.applicationDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// The bulk remove.
        /// </summary>
        /// <param name="invoices">
        /// The invoices.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task BulkRemove(List<Invoice> invoices)
        {
            await this.applicationDbContext.BulkDeleteAsync(invoices);
        }
    }
}
