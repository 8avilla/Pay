using Auto.Pay.Application.Dtos;
using Auto.Pay.BusinessLogic.Entities;

namespace Auto.Pay.Application.Interfaces
{
    //MAPEADO Y GENERADO POR EXPRESS CODE
    public partial interface IOrderApplication : IGenericApplication
	{
        EntityBusinessLogic RegisterOrder(RegisterOrderDTO dto);
        EntityBusinessLogic StatusOrden(string orderCredibancoId, string businessID);
    }
}
