// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginInput.cs" company="">
//   
// </copyright>
// <summary>
//   The login input.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace InvoiceSPA.Models
{
    /// <summary>
    /// The login input.
    /// </summary>
    public class LoginInput
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sers the remember
        /// </summary>
        public bool Remember { get; set; }
    }
}