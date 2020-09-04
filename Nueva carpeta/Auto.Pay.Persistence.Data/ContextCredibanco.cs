using Microsoft.EntityFrameworkCore;
using Auto.Pay.Persistence.Interface;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using Auto.Pay.Persistence.Entities;

namespace Auto.Pay.Persistence.Data
{
    public class ContextPay : DbContext, IContextPay
    {
        public ContextPay(DbContextOptions<ContextPay> options)
            : base(options)
        {
        }

        //public DbSet<Users> Users { get; set; }

        public DbSet<OrderEP> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }


    }
}

























































