using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentOptions.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentOptions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : Controller
    {
        private readonly PaymentDetailContext _context;


        public PaymentDetailController(PaymentDetailContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetails()
        {
            return await _context.paymentDetails.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int Id)
        {
            var paymentDetail = await _context.paymentDetails.FindAsync(Id);

            if(paymentDetail == null)
            {
                return NotFound();
            }

            return Ok(paymentDetail);
        }

        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail paymentDetail)
        {
            _context.paymentDetails.Add(paymentDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentDetail", new { id = paymentDetail.PaymentDetailId }, paymentDetail);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutPaymentDetail(int Id, PaymentDetail paymentDetail)
        {
            if(Id != paymentDetail.PaymentDetailId)
            {
                return BadRequest();
            }

            _context.Entry(paymentDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletePaymentDetail(int Id)
        {
            var paymentDetail = await _context.paymentDetails.FindAsync(Id);

            if(paymentDetail == null)
            {
                return NotFound();
            }

            _context.paymentDetails.Remove(paymentDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        public bool PaymentDetailExists(int Id)
        {
            return _context.paymentDetails.Any(x => x.PaymentDetailId == Id);
        }

    }
}
