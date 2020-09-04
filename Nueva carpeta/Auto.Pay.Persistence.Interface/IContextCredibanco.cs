using Auto.Pay.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auto.Pay.Persistence.Interface
{
    public interface IContextPay
    {
        //DbSet<Users> Users { get; set; }
        DbSet<OrderEP> Order { get; set; }
    }
}
