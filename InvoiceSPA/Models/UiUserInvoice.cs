// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UiUserInvoice.cs" company="">
//   
// </copyright>
// <summary>
//   The ui user invoice.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The ui user invoice.
    /// </summary>
    public class UiUserInvoice
    {
        /// <summary>
        /// Gets or sets the invoices created by user.
        /// </summary>
        public List<UiInvoice> InvoicesCreatedByUser { get; set; } = new List<UiInvoice>();

        /// <summary>
        /// Gets or sets the invoices approved by user.
        /// </summary>
        public List<UiInvoice> InvoicesApprovedByUser { get; set; } = new List<UiInvoice>();
    }
}
