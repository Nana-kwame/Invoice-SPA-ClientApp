// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceItemInput.cs" company="">
//   
// </copyright>
// <summary>
//   The invoice item input.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Models
{
    /// <summary>
    /// The invoice item input.
    /// </summary>
    public class InvoiceItemInput
    {
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
    }
}
