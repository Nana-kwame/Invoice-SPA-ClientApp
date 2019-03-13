namespace InvoiceSPA.Models
{
    public class PasswordHash
    {
        public string HashedPassword { get; set; }

        public string Salt { get; set; }
    }
}
