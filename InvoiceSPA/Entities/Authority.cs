// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Authority.cs" company="">
//   
// </copyright>
// <summary>
//   The authority.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Entities
{
    using System;

    /// <summary>
    /// The authority.
    /// </summary>
    public class Authority
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Gets or sets the approved on.
        /// </summary>
        public DateTime? ApprovedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether approved.
        /// </summary>
        public bool Approved { get; set; }

        /// <summary>
        /// Gets or sets the invoice id.
        /// </summary>
        public long InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets the invoice.
        /// </summary>
        public Invoice Invoice { get; set; }
    }
}
