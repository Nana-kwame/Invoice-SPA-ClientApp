// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRecipientService.cs" company="">
//   
// </copyright>
// <summary>
//   The RecipientService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using InvoiceSPA.Models;

    /// <summary>
    /// The RecipientService interface.
    /// </summary>
    public interface IRecipientService
    {
        /// <summary>
        /// The get recipient invoices.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="number"></param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<List<UiRecipient>> GetRecipientInvoices(string name, string number);

        /// <summary>
        /// The get recipient.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="number"></param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<List<UiRecipient>> GetRecipients(string name, string number);

        /// <summary>
        /// The delete recipient.
        /// </summary>
        /// <param name="deleteRecipientInput">
        /// The delete recipient input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ApiResponse> DeleteRecipient(DeleteRecipientInput deleteRecipientInput);
    }
}
