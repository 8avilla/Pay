using Auto.Pay.Persistence.Entities;

namespace Auto.Pay.Persistence.Interface
{
    public interface IUnitOfWorkPersistence
    {
        void SaveChanges();

        void LiberarRecursos();

        IGenericPersistenceRepository<OrderEP> Order { get; }
        IGenericPersistenceRepository<PaymentReferenceEP> PaymentReference { get; }

    }
}
