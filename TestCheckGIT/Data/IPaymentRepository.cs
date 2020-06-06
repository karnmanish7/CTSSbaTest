using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCheckGIT.Models;

namespace TestCheckGIT.Data
{
   public interface IPaymentRepository
    {
        public  Task<IEnumerable<PaymentDetails>> GetPaymentDetails();
        public Task<PaymentDetails> GetPaymentDetail(int id);
        public Task<int> PostPaymentDetails(PaymentDetails paymentDetails);
        public Task UpdatePaymentDetails(PaymentDetails paymentDetails);
    }
}
