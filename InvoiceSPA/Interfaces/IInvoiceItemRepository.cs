// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IInvoiceItemRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The InvoiceItemRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using InvoiceSPA.Entities;

    /// <summary>
    /// The InvoiceItemRepository interface.
    /// </summary>
    public interface IInvoiceItemRepository
    {
        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="invoiceItem">
        /// The invoice item.
        /// </param>
        void Add(InvoiceItem invoiceItem);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="invoiceItem">
        /// The invoice item.
        /// </param>
        void Update(InvoiceItem invoiceItem);

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="invoiceItem">
        /// The invoice item.
        /// </param>
        void Remove(InvoiceItem invoiceItem);

        /// <summary>
        /// The bulk remove.
        /// </summary>
        /// <param name="invoiceItems">
        /// The invoice items.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task BulkRemove(List<InvoiceItem> invoiceItems);
    }
}
