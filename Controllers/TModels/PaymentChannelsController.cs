using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentOptions.Data;
using PaymentOptions.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentOptions.Controllers.TModels
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentChannelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaymentChannelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<PaymentChannelController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentChannel>>> GetPaymentChannel()
        {
            return await _context.PaymentChannels.ToListAsync();
        }

        // GET api/<PaymentChannelController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentChannel>> GetPaymentChannel(int id)
        {
            var paymentChannel = await _context.PaymentChannels.FindAsync(id);
            if (paymentChannel == null)
            {
                return NotFound();
            }
            return paymentChannel;
        }

        // POST api/<PaymentChannelController>
        [HttpPost]
        public async Task<ActionResult<PaymentChannel>> PostPaymentChannel(PaymentChannel paymentChannel)
        {
            _context.PaymentChannels.Add(paymentChannel);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPaymentChannel", new { id = paymentChannel.PaymentChannelId }, paymentChannel);
        }

        // PUT api/<PaymentChannelController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentChannel(int id, PaymentChannel paymentChannel)
        {
            if (id != paymentChannel.PaymentChannelId) { 
                return BadRequest();
            }

            PaymentChannel _paymentChannel = new PaymentChannel { 
                PaymentChannelId = paymentChannel.PaymentChannelId,
                ChannelCode = paymentChannel.ChannelCode,
                ChannelName = paymentChannel.ChannelName,
                CreatedBy = paymentChannel.CreatedBy,
                DateCreated = paymentChannel.DateCreated,
                DateModified = paymentChannel.DateModified,
                IsActive = paymentChannel.IsActive,
                IsPartialPayment = paymentChannel.IsPartialPayment,
                ModifiedBy = paymentChannel.ModifiedBy
            };

            _context.Entry(_paymentChannel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) {
                throw;
            }
            return NoContent();
        }

        // DELETE api/<PaymentChannelController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentChannel(int id)
        {
            var _paymentChannel = await _context.FindAsync<PaymentChannel>(id);
            if (_paymentChannel != null)
            {
                _paymentChannel.IsActive = false;
                _context.Entry(_paymentChannel).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
