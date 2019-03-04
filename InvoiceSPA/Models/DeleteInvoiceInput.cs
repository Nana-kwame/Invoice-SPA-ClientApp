// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteInvoiceInput.cs" company="">
//   
// </copyright>
// <summary>
//   The delete invoice input.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The delete invoice input.
    /// </summary>
    public class DeleteInvoiceInput
    {
        /// <summary>
        /// Gets or sets the invoice id.
        /// </summary>
        public List<string> InvoiceIds { get; set; }
    }
}
