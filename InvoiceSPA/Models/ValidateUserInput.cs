using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceSPA.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ValidateUserInput
    {
        /// <summary>
        /// User last name
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// User Phone number
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }
    }
}
