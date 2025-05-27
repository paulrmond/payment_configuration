using System.ComponentModel.DataAnnotations;

namespace PaymentOptions.Model
{
    public class MCurrencyCode
    {
        [Key]
        public int CurrencyID { get; set; }
        public int Code { get; set; }
        public string CurrencyCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
