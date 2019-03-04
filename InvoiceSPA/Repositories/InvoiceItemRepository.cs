// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceItemRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The invoice item repository.
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

    /// <inheritdoc />
    /// <summary>
    /// The invoice item repository.
    /// </summary>
    public class InvoiceItemRepository : IInvoiceItemRepository
    {
        /// <summary>
        /// The application db context.
        /// </summary>
        private readonly ApplicationDbContext applicationDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceItemRepository"/> class.
        /// </summary>
        /// <param name="applicationDbContext">
        /// The application db context.
        /// </param>
        public InvoiceItemRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        /// <inheritdoc />
        /// <summary>
        /// The add.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public void Add(InvoiceItem invoiceItem)
        {
            this.applicationDbContext.InvoiceItems.Add(invoiceItem);
        }

        /// <inheritdoc />
        /// <summary>
        /// The update.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public void Update(InvoiceItem invoiceItem)
        {
            this.applicationDbContext.InvoiceItems.Update(invoiceItem);
        }

        /// <inheritdoc />
        /// <summary>
        /// The remove.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public void Remove(InvoiceItem invoiceItem)
        {
            this.applicationDbContext.InvoiceItems.Remove(invoiceItem);
        }

        /// <summary>
        /// The bulk remove.
        /// </summary>
        /// <param name="invoiceItems">
        /// The invoice items.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task BulkRemove(List<InvoiceItem> invoiceItems)
        {
            await this.applicationDbContext.BulkDeleteAsync(invoiceItems);
        }
    }
}
