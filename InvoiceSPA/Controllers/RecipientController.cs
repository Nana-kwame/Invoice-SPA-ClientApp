// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipientController.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the RecipientController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using InvoiceSPA.Interfaces;
    using InvoiceSPA.Models;

    using Microsoft.AspNetCore.Mvc;

    /// <inheritdoc />
    /// <summary>
    /// The recipient controller.
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class RecipientController : Controller
    {
        /// <summary>
        /// The recipient service.
        /// </summary>
        private readonly IRecipientService recipientService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipientController"/> class.
        /// </summary>
        /// <param name="recipientService">
        /// The recipient service.
        /// </param>
        public RecipientController(IRecipientService recipientService)
        {
            this.recipientService = recipientService;
        }

        /// <summary>
        /// The get recipient invoice.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetRecipientInvoice([FromQuery]string name, [FromQuery]string number)
        {
            if (string.IsNullOrEmpty(name)
                && string.IsNullOrEmpty(number))
            {
                return this.BadRequest(new List<UiRecipient>());
            }

            try
            {
                var recipients = await this.recipientService.GetRecipientInvoices(name, number);

                if (recipients.Any())
                {
                    return this.Ok(recipients);
                }

                return this.NotFound(recipients);
            }
            catch (Exception exception)
            {
                return this.StatusCode(
                    500,
                    new ApiResponse
                    {
                        IsSuccessful = false,
                        Message = exception.InnerException.Message
                    });
            }
        }

        /// <summary>
        /// The get recipient invoice.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetRecipient([FromQuery]string name, [FromQuery]string number)
        {
            if (string.IsNullOrEmpty(name)
                && string.IsNullOrEmpty(number))
            {
                return this.BadRequest(new List<UiRecipient>());
            }

            try
            {
                var recipients = await this.recipientService.GetRecipients(name, number);

                if (recipients.Any())
                {
                    return this.Ok(recipients);
                }

                return this.NotFound(recipients);
            }
            catch (Exception exception)
            {
                return this.StatusCode(
                    500,
                    new ApiResponse
                    {
                        IsSuccessful = false,
                        Message = exception.InnerException.Message
                    });
            }
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="deleteRecipientInput">
        /// The delete Recipient Input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]DeleteRecipientInput deleteRecipientInput)
        {
            var apiResponse = new ApiResponse();

            if (!this.ModelState.IsValid)
            {
                apiResponse.IsSuccessful = false;

                return this.BadRequest(apiResponse);
            }

            try
            {
                apiResponse = await this.recipientService.DeleteRecipient(deleteRecipientInput);

                if (apiResponse.IsSuccessful)
                {
                    return this.Ok(apiResponse);
                }

                return this.BadRequest(apiResponse);
            }
            catch (Exception exception)
            {
                return this.StatusCode(
                    500,
                    new ApiResponse
                    {
                        IsSuccessful = false,
                        Message = exception.InnerException.Message
                    });
            }
        }
    }
}
