// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateInvoiceInput.cs" company="">
//   
// </copyright>
// <summary>
//   The update invoice input.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The update invoice input.
    /// </summary>
    public class UpdateInvoiceInput
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the invoice no.
        /// </summary>
        [Required]
        public string InvoiceNo { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        [Required]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the last updated.
        /// </summary>
        public DateTime? LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets the invoice items.
        /// </summary>
        public IEnumerable<InvoiceItemInput> InvoiceItems { get; set; }

        /// <summary>
        /// Gets or sets the authorities.
        /// </summary>
        public IEnumerable<AuthorityInput> Authorities { get; set; }
    }
}
