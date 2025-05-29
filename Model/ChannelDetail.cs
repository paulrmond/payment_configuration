using System.ComponentModel.DataAnnotations;

namespace PaymentOptions.Model
{
    public class ChannelDetail
    {
        [Key]
        public int ChannelDetailId { get; set; }
        public string ProductName { get; set; }
        public string ChannelName { get; set; }
        public string PlatformName { get; set; }
    }
}
