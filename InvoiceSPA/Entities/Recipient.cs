// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Recipient.cs" company="">
//   
// </copyright>
// <summary>
//   The recipient.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// The recipient.
    /// </summary>
    public class Recipient
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public long Id { get; set; }

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
        /// Gets or sets a value indicating whether is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the invoice.
        /// </summary>
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
