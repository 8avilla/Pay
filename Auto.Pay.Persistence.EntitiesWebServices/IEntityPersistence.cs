using System;

namespace Auto.Pay.Persistence.Entities
{
    public interface IEntityPersistence
    {
        long Id { get; set; }
        DateTime CreationDate { get; set; }
    }
}
