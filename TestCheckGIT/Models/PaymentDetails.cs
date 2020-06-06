using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestCheckGIT.Models
{
    public class PaymentDetails
    {
        [Key]
        public int PMID { get; set; }
        public string CardHolderName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CardNumber { get; set; }
        public int cvv { get; set; }
    }
}
