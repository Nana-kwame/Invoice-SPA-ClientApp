namespace InvoiceSPA.Entities
{
    public class ApplicationUser
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Hashed Password
        /// </summary>
        public string HashedPassword { get; set; }

        /// <summary>
        /// Salt for hashing
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// User first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// User phone number
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
