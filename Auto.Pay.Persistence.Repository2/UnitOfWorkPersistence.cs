using Auto.Pay.Persistence.Data;
using Auto.Pay.Persistence.Entities;
using Auto.Pay.Persistence.Interface;
using System;

namespace Auto.Pay.Persistence.Repository
{
    public class UnitOfWorkPersistence : IUnitOfWorkPersistence
    {
        private readonly ContextPay _contextoPay;
        public UnitOfWorkPersistence(ContextPay dbContext)
        {
            _contextoPay = dbContext;
        }

        private bool disposed = false;

        private IGenericPersistenceRepository<OrderEP> OrderRepository;
        public IGenericPersistenceRepository<OrderEP> Order => OrderRepository ?? (OrderRepository = new GenericPersistenceRepository<OrderEP>(_contextoPay));
        

        private IGenericPersistenceRepository<PaymentReferenceEP> PaymentReferenceRepository;
        public IGenericPersistenceRepository<PaymentReferenceEP> PaymentReference => PaymentReferenceRepository ??= new GenericPersistenceRepository<PaymentReferenceEP>(_contextoPay);

        public void SaveChanges()
        {
            _contextoPay.SaveChanges();
        }


        protected virtual void LiberarRecursos(bool disposing)
        {
            if (!disposed && disposing)
            {
                _contextoPay.Dispose();
            }

            disposed = true;
        }
        public void LiberarRecursos()
        {
            LiberarRecursos(true);
            GC.SuppressFinalize(this);
        }

    }
}
