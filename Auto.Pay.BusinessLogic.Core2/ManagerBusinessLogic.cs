using Auto.Pay.Persistence.Interface;
using Microsoft.Extensions.Configuration;

namespace Auto.Pay.BusinessLogic.Core
{
    public class ManagerBusinessLogic: IManagerBusinessLogic
    {
        private readonly IUnitOfWorkPersistence _unitOfWorkInfrastructure;
        private readonly IConfiguration _configuracion;

        public ManagerBusinessLogic(IUnitOfWorkPersistence unitOfWorkInfrastructure, IConfiguration iConfig)
        {
            _unitOfWorkInfrastructure = unitOfWorkInfrastructure;
            _configuracion = iConfig;
        }
        public OrderBusinessLogic Order => new OrderBusinessLogic(_unitOfWorkInfrastructure, _configuracion);
        public PaymentReferenceBusinessLogic PaymentReference => new PaymentReferenceBusinessLogic(_unitOfWorkInfrastructure, _configuracion);
    }
}
