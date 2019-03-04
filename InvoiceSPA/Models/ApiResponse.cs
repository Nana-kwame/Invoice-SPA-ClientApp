// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SuccessResponse.cs" company="">
//   
// </copyright>
// <summary>
//   The success response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Models
{
    /// <summary>
    /// The success response.
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether is successful.
        /// </summary>
        public bool IsSuccessful { get; set;  }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }
    }
}
