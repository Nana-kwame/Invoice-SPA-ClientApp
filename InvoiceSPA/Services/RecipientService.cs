// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipientService.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the RecipientService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using InvoiceSPA.Entities;
    using InvoiceSPA.Interfaces;
    using InvoiceSPA.Models;

    /// <inheritdoc />
    /// <summary>
    /// The recipient service.
    /// </summary>
    public class RecipientService : IRecipientService
    {
        /// <summary>
        /// The recipient repository.
        /// </summary>
        private readonly IRecipientRepository recipientRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipientService"/> class.
        /// </summary>
        /// <param name="recipientRepository">
        /// The recipient repository.
        /// </param>
        public RecipientService(IRecipientRepository recipientRepository)
        {
            this.recipientRepository = recipientRepository;
        }

        /// <inheritdoc />
        /// <summary>
        /// The get recipient invoices.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="number"></param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public async Task<List<UiRecipient>> GetRecipientInvoices(string name, string number)
        {
            var recipients = await this.GetRecipient(name, number);

            if (!recipients.Any())
            {
                return new List<UiRecipient>();
            }

            var uiRecipients = new List<UiRecipient>();

            foreach (var recipient in recipients)
            {
                var uiRecipient = new UiRecipient
                {
                    Name = recipient.Name,
                    Address = recipient.Address,
                    RecipientNumber = recipient.RecipientNumber
                };

                var invoices = recipient.Invoices.Select(
                    x => new UiInvoice
                    {
                        CreatedBy = x.CreatedBy,
                        InvoiceNo = x.InvoiceNo,
                        Approved = x.Approved,
                        CreatedOn = x.CreatedOn,
                        LastUpdated = x.LastUpdated,
                        Status = x.Status,
                        Title = x.Title
                    });

                uiRecipient.Invoices.AddRange(invoices);
                uiRecipients.Add(uiRecipient);
            }

            return uiRecipients;
        }

        /// <inheritdoc />
        /// <summary>
        /// The get recipients.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public async Task<List<UiRecipient>> GetRecipients(string name, string number)
        {
            var recipients = await this.GetRecipient(name, number);

            if (!recipients.Any())
            {
                return new List<UiRecipient>();
            }

            var uiRecipients = new List<UiRecipient>();

            foreach (var recipient in recipients)
            {
                var uiRecipient = new UiRecipient
                {
                    Name = recipient.Name,
                    Address = recipient.Address,
                    RecipientNumber = recipient.RecipientNumber
                };

                uiRecipients.Add(uiRecipient);
            }

            return uiRecipients;
        }

        /// <inheritdoc />
        /// <summary>
        /// The delete recipient.
        /// </summary>
        /// <param name="deleteRecipientInput">
        /// The delete recipient input.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public async Task<ApiResponse> DeleteRecipient(DeleteRecipientInput deleteRecipientInput)
        {
            foreach (var recipientNo in deleteRecipientInput.RecipientNo)
            {
                var recipient = await this.recipientRepository.FindById(recipientNo);

                if (recipient == null)
                {
                    continue;
                }

                recipient.IsDeleted = true;

                this.recipientRepository.Update(recipient);
            }

            await this.recipientRepository.SaveChanges();

            return new ApiResponse
            {
                IsSuccessful = true,
                Message = "Recipient Deleted"
            };
        }


        /// <summary>
        /// The get recipient.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="number"></param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        private async Task<List<Recipient>> GetRecipient(string name, string number)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var recipients = await this.recipientRepository.FindByName(name);

                return !recipients.Any() ? new List<Recipient>() : recipients;
            }
            else if (!string.IsNullOrEmpty(number))
            {
                var recipient = await this.recipientRepository.FindById(number);

                return recipient == null ? new List<Recipient>() : new List<Recipient> { recipient };
            }

            return new List<Recipient>();
        }
    }
}
