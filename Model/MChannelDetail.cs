using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentOptions.Model
{
    [Table("MChannelDetails")]
    public class MChannelDetail
    {
        [Key]
        public int ChannelDetailId { get; set; }
        public string ProductName { get; set; }
        public string ChannelName { get; set; }
        public string PlatformName { get; set; }

        public string ProductCode { get; set; }
    }
}
