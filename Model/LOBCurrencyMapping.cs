using System.ComponentModel.DataAnnotations;

namespace PaymentOptions.Model
{
    public class LOBCurrencyMapping
    {
        [Key]
        public int LOBCurrencyMappingId { get; set; }
        public int PaymentMethodId { get; set; }
        public int LobId { get; set; }
        public int CurrencyID { get; set; }
        
    }
}
