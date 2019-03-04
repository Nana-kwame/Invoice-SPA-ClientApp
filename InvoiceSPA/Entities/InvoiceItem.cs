// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceItem.cs" company="">
//   
// </copyright>
// <summary>
//   The invoice item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Entities
{
    /// <summary>
    /// The invoice item.
    /// </summary>
    public class InvoiceItem
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
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public string Amount { get; set; }

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
