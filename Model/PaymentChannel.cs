using System.ComponentModel.DataAnnotations;

namespace PaymentOptions.Model
{
    public class PaymentChannel
    {
        [Key]
        public int PaymentChannelId { get; set; }
        public string ChannelCode { get; set; }
        public string ChannelName { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public String CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsPartialPayment { get; set; }
        public List<PaymentTab> Tabs { get; set; }
    }
}
