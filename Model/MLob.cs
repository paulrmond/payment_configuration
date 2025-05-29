using System.ComponentModel.DataAnnotations;

namespace PaymentOptions.Model
{
    public class MLob
    {
        [Key]
        public int LobId { get; set; }
        public string LobName { get; set; }
        public string Address { get; set; }
        public string ChannelHash { get; set; }
    }
}
