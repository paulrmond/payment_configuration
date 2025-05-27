using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentOptions.Model
{
    public class MCarrierCode
    {
        [Key]
        public int CarrierID { get; set; }
        public int Code { get; set; }
        public string CarrierCode { get; set; }
        public string CreatedBy { get; set; }
        //[Column(TypeName = "DATE")]
        public DateTime DateCreated { get; set; }
    }
}
