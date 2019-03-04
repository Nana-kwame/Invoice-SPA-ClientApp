// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceController.cs" company="">
//   
// </copyright>
// <summary>
//   The invoice controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using InvoiceSPA.Interfaces;
    using InvoiceSPA.Models;

    using Microsoft.AspNetCore.Mvc;

    /// <inheritdoc />
    /// <summary>
    /// The invoice controller.
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class InvoiceController : Controller
    {
        /// <summary>
        /// The invoice service.
        /// </summary>
        private readonly IInvoiceService invoiceService;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceController"/> class.
        /// </summary>
        /// <param name="invoiceService">
        /// The invoice service.
        /// </param>
        public InvoiceController(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="createInvoiceInput">
        /// The create Invoice Input.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateInvoiceInput createInvoiceInput)
        {
            var apiResponse = new ApiResponse();

            if (!this.ModelState.IsValid)
            {
                apiResponse.IsSuccessful = false;

                return this.BadRequest(apiResponse);
            }

            try
            {
                apiResponse = await this.invoiceService.CreateInvoice(createInvoiceInput);

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

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="updateInvoiceInput">
        /// The update invoice input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateInvoiceInput updateInvoiceInput)
        {
            var apiResponse = new ApiResponse();

            if (!this.ModelState.IsValid)
            {
                apiResponse.IsSuccessful = false;

                return this.BadRequest(apiResponse);
            }

            try
            {
                apiResponse = await this.invoiceService.UpdateInvoice(updateInvoiceInput);

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

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="deleteInvoiceInput">
        /// The delete Invoice Input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]DeleteInvoiceInput deleteInvoiceInput)
        {
            var apiResponse = new ApiResponse();

            if (!this.ModelState.IsValid)
            {
                apiResponse.IsSuccessful = false;

                return this.BadRequest(apiResponse);
            }

            try
            {
                apiResponse = await this.invoiceService.DeleteInvoice(deleteInvoiceInput);

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

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return this.BadRequest(new UiInvoice());
            }

            try
            {
                var uiInvoice = await this.invoiceService.GetInvoice(id);

                if (!string.IsNullOrEmpty(uiInvoice.InvoiceNo))
                {
                    return this.Ok(uiInvoice);
                }

                return this.BadRequest(uiInvoice);
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
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetUserInvoices([FromQuery]string user)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrWhiteSpace(user))
            {
                return this.BadRequest(new UiUserInvoice());
            }

            try
            {
                var uiUserInvoices = await this.invoiceService.GetUserInvoices(user);

                if (uiUserInvoices.InvoicesApprovedByUser.Any() || uiUserInvoices.InvoicesCreatedByUser.Any())
                {
                    return this.Ok(uiUserInvoices);
                }

                return this.BadRequest(uiUserInvoices);
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
        /// The approve invoice.
        /// </summary>
        /// <param name="approveInvoiceInput">
        /// The approve invoice input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> ApproveInvoice([FromBody]ApproveInvoiceInput approveInvoiceInput)
        {
            var apiResponse = new ApiResponse();

            if (!this.ModelState.IsValid)
            {
                apiResponse.IsSuccessful = false;

                return this.BadRequest(apiResponse);
            }

            try
            {
                apiResponse = await this.invoiceService.ApproveInvoice(approveInvoiceInput);

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
