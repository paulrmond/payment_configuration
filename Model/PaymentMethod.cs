using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentOptions.Model
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }
        public string PayMethodCode { get; set; }
        public string PayMethodName { get; set; }
        public int PreExpand { get; set; }
        public int SortOrder { get; set; }
        public int IsActive { get; set; }
        public string ProcessingFeeCodes { get; set; }
        public string SupportedBanksImage { get; set; }
        public string GatewayId { get; set; }
        public string FiCode { get; set; }
        public string SessionId { get; set; }
        public string MoreInfoUrl { get; set; }
        public string Discount { get; set; }
        public string MLobs { get; set; }
        public string CultureIds { get; set; }
        public string CurrencyIds { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public String CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        [ForeignKey("PaymentTab")]
        public int PaymentTabId { get; set; }
        public PaymentTab PaymentTab { get; set; }

    }
}
