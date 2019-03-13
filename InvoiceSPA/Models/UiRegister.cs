using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceSPA.Models
{
    public class UiRegister
    {
        /// <summary>
        /// Username
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Hashed Password
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// User first name
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// User last name
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// User phone number
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }
    }
}
