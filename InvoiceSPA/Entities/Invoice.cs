// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Invoice.cs" company="">
//   
// </copyright>
// <summary>
//   The invoice.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Entities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The invoice.
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public long Id { get; set; }

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
        /// Gets or sets a value indicating whether is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the recipient.
        /// </summary>
        public Recipient Recipient { get; set; }

        /// <summary>
        /// Gets or sets the authorities.
        /// </summary>
        public List<Authority> Authorities { get; set; } = new List<Authority>();

        /// <summary>
        /// Gets or sets the invoice items.
        /// </summary>
        public List<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }
}
