using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentOptions.Data;
using PaymentOptions.Model;

namespace PaymentOptions.Controllers.TModels
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTabsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaymentTabsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentTabs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentTab>>> GetPaymentTabs()
        {
            return await _context.PaymentTabs.ToListAsync();
        }

        // GET: api/PaymentTabs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentTab>> GetPaymentTab(int id)
        {
            var paymentTab = await _context.PaymentTabs.FindAsync(id);

            if (paymentTab == null)
            {
                return NotFound();
            }

            return paymentTab;
        }

        // PUT: api/PaymentTabs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentTab(int id, PaymentTab paymentTab)
        {
            if (id != paymentTab.PaymentTabId)
            {
                return BadRequest();
            }

            _context.Entry(paymentTab).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTabExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PaymentTabs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentTab>> PostPaymentTab(PaymentTab paymentTab)
        {
            _context.PaymentTabs.Add(paymentTab);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentTab", new { id = paymentTab.PaymentTabId }, paymentTab);
        }

        // DELETE: api/PaymentTabs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentTab(int id)
        {
            var paymentTab = await _context.PaymentTabs.FindAsync(id);
            if (paymentTab == null)
            {
                return NotFound();
            }

            _context.PaymentTabs.Remove(paymentTab);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentTabExists(int id)
        {
            return _context.PaymentTabs.Any(e => e.PaymentTabId == id);
        }
    }
}
