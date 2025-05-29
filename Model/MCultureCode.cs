using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentOptions.Model
{
    public class MCultureCode
    {
        [Key]
        public int CultureID { get; set; }
        public int Code { get; set; }
        public string CultureCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
