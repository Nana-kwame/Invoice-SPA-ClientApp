// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IInvoiceService.cs" company="">
//   
// </copyright>
// <summary>
//   The InvoiceService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Interfaces
{
    using System.Threading.Tasks;

    using InvoiceSPA.Models;

    /// <summary>
    /// The InvoiceService interface.
    /// </summary>
    public interface IInvoiceService
    {
        /// <summary>
        /// The create invoice.
        /// </summary>
        /// <param name="createInvoiceInput">
        /// The create invoice input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ApiResponse> CreateInvoice(CreateInvoiceInput createInvoiceInput);

        /// <summary>
        /// The update invoice.
        /// </summary>
        /// <param name="updateInvoiceInput">
        /// The update invoice input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ApiResponse> UpdateInvoice(UpdateInvoiceInput updateInvoiceInput);

        /// <summary>
        /// The delete invoice.
        /// </summary>
        /// <param name="deleteInvoiceInput">
        /// The delete invoice input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ApiResponse> DeleteInvoice(DeleteInvoiceInput deleteInvoiceInput);

        /// <summary>
        /// The get invoice.
        /// </summary>
        /// <param name="invoiceNo">
        /// The invoice no.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<UiInvoice> GetInvoice(string invoiceNo);

        /// <summary>
        /// The get user invoices.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<UiUserInvoice> GetUserInvoices(string user);

        /// <summary>
        /// The approve invoice.
        /// </summary>
        /// <param name="approveInvoiceInput">
        /// The approve invoice input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ApiResponse> ApproveInvoice(ApproveInvoiceInput approveInvoiceInput);
    }
}
