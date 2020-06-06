using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestCheckGIT.Models
{
    public class PaymentDetails
    {
        [Key]
        public int PMID { get; set; }
        [Required]
        public string CardHolderName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
        [Required]
        [Display(Name = "card number")]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "Please Provide cvv details here")]
        
        
        public int cvv { get; set; }
    }
}
