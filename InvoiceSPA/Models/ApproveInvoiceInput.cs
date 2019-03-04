// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApproveInvoiceInput.cs" company="">
//   
// </copyright>
// <summary>
//   The approve invoice input.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Models
{
    /// <summary>
    /// The approve invoice input.
    /// </summary>
    public class ApproveInvoiceInput
    {
        /// <summary>
        /// Gets or sets a value indicating whether approve.
        /// </summary>
        public bool Approve { get; set; }

        /// <summary>
        /// Gets or sets the invoice id.
        /// </summary>
        public string InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets the authority.
        /// </summary>
        public string Authority { get; set; }
    }
}
