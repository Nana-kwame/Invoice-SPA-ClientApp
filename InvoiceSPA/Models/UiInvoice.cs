// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UiInvoice.cs" company="">
//   
// </copyright>
// <summary>
//   The ui invoice.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The ui invoice.
    /// </summary>
    public class UiInvoice
    {
        /// <summary>
        /// Gets or sets the invoice no.
        /// </summary>
        public string InvoiceNo { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the last updated.
        /// </summary>
        public DateTime? LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether signed off.
        /// </summary>
        public bool Approved { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether complete.
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Gets or sets the recipient.
        /// </summary>
        public UiRecipient Recipient { get; set; }

        /// <summary>
        /// Gets or sets the invoice items.
        /// </summary>
        public List<UiInvoiceItem> InvoiceItems { get; set; } = new List<UiInvoiceItem>();

        /// <summary>
        /// Gets or sets the authorities.
        /// </summary>
        public List<UiAuthority> Authorities { get; set; } = new List<UiAuthority>();
    }
}
