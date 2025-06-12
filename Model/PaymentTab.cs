using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentOptions.Model
{
    public class PaymentTab
    {
        [Key] 
        public int PaymentTabId { get; set; }
        public string TabCode { get; set; }
        public string Description { get; set; }
        public string PreExpand { get; set; }
        public string ChannelHashId { get; set; }
        public string LobId { get; set; }
        public int SortOrder { get; set; }
        public int IsActive { get; set; }
        public int DisplayMethodName { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public String CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsPartialPayment { get; set; }
        public bool EnableChannelHash { get; set; }
        public bool EnableLob { get; set; }
        [ForeignKey("PaymentChannel")]
        public int PaymentChannelId { get; set; }
        public PaymentChannel Channel { get; set; }
        public List<PaymentMethod> PaymentMethods { get; set; }
    }
}
