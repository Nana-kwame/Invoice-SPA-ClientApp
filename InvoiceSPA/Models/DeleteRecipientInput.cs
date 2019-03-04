namespace InvoiceSPA.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The delete recipient input.
    /// </summary>
    public class DeleteRecipientInput
    {
        /// <summary>
        /// Gets or sets the recipient no.
        /// </summary>
        public List<string> RecipientNo { get; set; }
    }
}
