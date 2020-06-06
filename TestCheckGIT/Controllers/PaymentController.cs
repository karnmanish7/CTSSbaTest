using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TestCheckGIT.Data;
using TestCheckGIT.Models;

namespace TestCheckGIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IPaymentRepository _paymentRepo;

        public PaymentController(IConfiguration config,IPaymentRepository paymentRepo)
        {
            _config = config;
            _paymentRepo = paymentRepo;
        }

        // GET: api/PaymentDetail
        [HttpGet]
        [Route("GetPaymentDetails")]
        public async Task<IActionResult> GetPaymentDetails()
        {
            try
            {
                var cardDetails = await _paymentRepo.GetPaymentDetails();
                if (cardDetails.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(cardDetails);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetPaymentDetail/{id?}")]
        public async Task<IActionResult> GetPaymentDetail(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                var getOnecardDetail = await _paymentRepo.GetPaymentDetail(id);
                if (getOnecardDetail == null)
                {
                    return NotFound();
                }
                return Ok(getOnecardDetail);
            }
            catch (Exception)
            {

                return BadRequest();
            }
            

        }

        [HttpPost]
        [Route("PostPaymentDetails")]
        public async  Task<IActionResult> PostPaymentDetails(PaymentDetails paymentDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _paymentRepo.PostPaymentDetails(paymentDetails);
                    if (postId > 0)
                    {
                        return Ok(postId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdatePaymentDetails")]
        public async Task<IActionResult> UpdatePaymentDetails(PaymentDetails paymentDetails)
        {
            if (paymentDetails.PMID==null|| paymentDetails.PMID==0)
            {
                return BadRequest();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    await _paymentRepo.UpdatePaymentDetails(paymentDetails);
                    return Ok();
                }
                catch (Exception ex)
                {
  
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteDetails/{id}")]
        public async Task<IActionResult> DeleteDetails(int? id)
        {
            int result = 0;
            if (id == null ||id==0)
            {
                return BadRequest();
            }
            try
            {
                 result =await _paymentRepo.DeleteDetails(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
     
    }
}