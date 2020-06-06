using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                await _context.PaymentDetails.AddAsync(paymentDetails);
                await _context.SaveChangesAsync();
                return paymentDetails.PMID;
            }
            return 0;
            
        }
        public async Task UpdatePaymentDetails(PaymentDetails paymentDetails)
        {
            try
            {
                    _context.PaymentDetails.Update(paymentDetails);
                    await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //if (!PaymentDetailsExists(paymentDetails.PMID)){
                //    throw ex;
                //}
                throw;
                    
            }
                
        }
        private bool PaymentDetailsExists(int? id)
        {
            return _context.PaymentDetails.Any(e => e.PMID == id);
        }
        public async Task<int> DeleteDetails(int? id)
        {
            int result = 0;
            try
            {
                
                var post = await _context.PaymentDetails.FirstOrDefaultAsync(x => x.PMID == id);
                if (post != null)
                {
                    _context.PaymentDetails.Remove(post);
                    result = await _context.SaveChangesAsync();
                    return result;
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
