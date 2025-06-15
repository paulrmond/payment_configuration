using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentOptions.Data;
using PaymentOptions.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentOptions.Controllers.TModels
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentOptionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PaymentOptionsController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        // GET: api/<PaymentOptionsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentMethod>>> Get()
        {
            List<LOBCurrencyMapping> lOBCurrencyMappings = new List<LOBCurrencyMapping>();
            List<PaymentMethod> payment_method = new List<PaymentMethod>();
            payment_method = await _context.PaymentMethods.ToListAsync();
            foreach (var item in payment_method)
            {
                var tempLobCurrencyMapping = await _context.LOBCurrencyMappings.Where(x => x.PaymentMethodId == item.PaymentMethodId).ToListAsync();
                //Referenced to current object
                item.LOBCurrencyMapping = tempLobCurrencyMapping;
            }
            return payment_method;
        }

        // GET api/<PaymentOptionsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentMethod>> Get(int id)
        {
            List<LOBCurrencyMapping> lOBCurrencyMappings = new List<LOBCurrencyMapping>();
            PaymentMethod payment_method = new PaymentMethod();
            payment_method = await _context.PaymentMethods.FindAsync(id);
            if (payment_method == null)
                return payment_method;

            var tempLobCurrencyMapping = await _context.LOBCurrencyMappings.Where(x => x.PaymentMethodId == id).ToListAsync();
            //Referenced to current object
            payment_method.LOBCurrencyMapping = tempLobCurrencyMapping;
            
            return payment_method;
        }

        // POST api/<PaymentOptionsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PaymentOptionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PaymentOptionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
