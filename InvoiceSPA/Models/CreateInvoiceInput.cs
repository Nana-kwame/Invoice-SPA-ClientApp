// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateInvoiceInput.cs" company="">
//   
// </copyright>
// <summary>
//   The create invoice input.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The create invoice input.
    /// </summary>
    public class CreateInvoiceInput
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
        /// Gets or sets the title.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the last updated.
        /// </summary>
        public DateTime? LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets the invoice items.
        /// </summary>
        [Required]
        public IEnumerable<InvoiceItemInput> InvoiceItems { get; set; }

        /// <summary>
        /// Gets or sets the authorities.
        /// </summary>
        [Required]
        public IEnumerable<AuthorityInput> Authorities { get; set; }
    }
}
