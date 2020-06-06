using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCheckGIT.Models;

namespace TestCheckGIT.Data
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly DataContext _context;
        public PaymentRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<PaymentDetails>> GetPaymentDetails()
        {
            if (_context!=null)
            {
                var getDetails = await _context.PaymentDetails.ToListAsync();

                return getDetails;
            }
            return null;
               
        }
        public async Task<PaymentDetails> GetPaymentDetail(int id)
        {
            if (_context != null)
            {
                var result = await _context.PaymentDetails.FindAsync(id);

                return result;
            }
            return null;

        }
        public async Task<int> PostPaymentDetails(PaymentDetails paymentDetails)
        {
            if (_context != null)
            {
                _context.PaymentDetails.Add(paymentDetails);
                await _context.SaveChangesAsync();
                return paymentDetails.PMID;
            }
            return 0;
            
        }
        public async Task UpdatePaymentDetails(PaymentDetails paymentDetails)
        {
                _context.PaymentDetails.Update(paymentDetails);
                await _context.SaveChangesAsync();
            

        }
    }
}
