using Microsoft.EntityFrameworkCore;

namespace PaymentOptions.Models
{
    public class PaymentDetailContext: DbContext
    {
        public PaymentDetailContext(DbContextOptions<PaymentDetailContext> options): base(options)
        {

        }

        public DbSet<PaymentDetail> paymentDetails { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}
