// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UiRecipient.cs" company="">
//   
// </copyright>
// <summary>
//   The ui recipient.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The ui recipient.
    /// </summary>
    public class UiRecipient
    {
        /// <summary>
        /// Gets or sets the recipient no.
        /// </summary>
        public string RecipientNumber { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the invoices.
        /// </summary>
        public List<UiInvoice> Invoices { get; set; } = new List<UiInvoice>();
    }
}
