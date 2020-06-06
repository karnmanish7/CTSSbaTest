using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCheckGIT.Models
{
    public class PaymentDetails
    {
        public string CardHolderName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CardNumber { get; set; }
        public int cvv { get; set; }
    }
}
