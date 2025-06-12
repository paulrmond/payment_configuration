using System.ComponentModel.DataAnnotations;

namespace PaymentOptions.Model
{
    public class MChannelHash
    {
        [Key]
        public int ChannelHashId { get; set; }
        public string ChannelHashName { get; set; }
        public string ChannelHashInfo { get; set; }
        public string ChannelHash { get; set; }
    }
}
