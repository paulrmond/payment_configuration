using Microsoft.EntityFrameworkCore;
using PaymentOptions.Data;

namespace PaymentOptions.Helper
{
    public class InitiateMethods
    {
        public InitiateMethods(ApplicationDbContext applicationDbContext) 
        { 
            using(ApplicationDbContext context = applicationDbContext)
            {
                context.Database.EnsureCreated();
                if(context.Database.GetPendingMigrations().Count() > 0)
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
