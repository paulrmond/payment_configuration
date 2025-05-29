using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
