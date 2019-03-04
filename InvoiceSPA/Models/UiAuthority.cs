// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UiAuthority.cs" company="">
//   
// </copyright>
// <summary>
//   The ui authority.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Models
{
    using System;

    /// <summary>
    /// The ui authority.
    /// </summary>
    public class UiAuthority
    {
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
    }
}
