// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IInvoiceRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The InvoiceRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using InvoiceSPA.Entities;

    /// <summary>
    /// The InvoiceRepository interface.
    /// </summary>
    public interface IInvoiceRepository
    {
        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="invoice">
        /// The invoice.
        /// </param>
        void Add(Invoice invoice);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="invoice">
        /// The invoice.
        /// </param>
        void Update(Invoice invoice);

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="invoice">
        /// The invoice.
        /// </param>
        void Remove(Invoice invoice);

        /// <summary>
        /// The find by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<Invoice> FindById(string id);

        /// <summary>
        /// The find by creator.
        /// </summary>
        /// <param name="creator">
        /// The creator.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<List<Invoice>> FindByCreator(string creator);

        /// <summary>
        /// The save changes.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task SaveChanges();

        /// <summary>
        /// The bulk remove.
        /// </summary>
        /// <param name="invoices">
        /// The invoices.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task BulkRemove(List<Invoice> invoices);

        /// <summary>
        /// The get invoice count.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int GetInvoiceCount();
    }
}
