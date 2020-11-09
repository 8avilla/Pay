using Auto.Pay.Application.Dtos;
using Auto.Pay.Application.Interfaces;
using Auto.Pay.BusinessLogic.Core;
using Auto.Pay.BusinessLogic.Entities;

namespace Auto.Pay.Application.Main
{
    //MAPEADO Y GENERADO POR EXPRESS CODE
    public class OrderApplication : IOrderApplication
	{
		private readonly IManagerBusinessLogic _managerBusinessLogic;
		public OrderApplication(IManagerBusinessLogic managerBusinessLogic)
		{
			_managerBusinessLogic = managerBusinessLogic;
		}


		//Agregar
		public EntityBusinessLogic RegisterOrder(RegisterOrderDTO registerOrderDTO)
		{
            RequestRegisterOrderCredibancoEBL orderEBL = registerOrderDTO.ConvertToEntity();

            return _managerBusinessLogic.Order.RegisterOrder(orderEBL);
		}
		public EntityBusinessLogic StatusOrden(string orderCredibancoId, string businessID)
        {
            return _managerBusinessLogic.Order.StatusOrden(orderCredibancoId, businessID);
		}


        //// METODO AGREGAR RANGO
        //public  IEnumerable<OrderDto> AgregarRango(IEnumerable<OrderDto> listaOrderDto)
        //{
        //	return _OrderDomain.AgregarRango(listaOrderDto.ConvertToEntity()).ConvertToDto();
        //}

        ////Modificar
        //public OrderDto Modificar(OrderDto entityDto)
        //{
        //	return _OrderDomain.Modificar(entityDto.ConvertToEntity()).ConvertToDto();
        //}

        ////Eliminar
        //public OrderDto Eliminar(int iDOrder)
        //{
        //		return _OrderDomain.Eliminar(iDOrder).ConvertToDto();
        //}

        ////Buscar Por Id
        //public OrderDto BuscarPorId(int iDOrder)
        //{
        //	return _OrderDomain.BuscarPorId(iDOrder).ConvertToDto();
        //}

        ////Buscar Por Id Con Dependencia
        //public OrderDto BuscarPorIdConDependencia(int iDOrder)
        //{
        //	return _OrderDomain.BuscarPorIdConDependencia(iDOrder).ConvertToDto();
        //}

        ////Buscar Todos
        //public IEnumerable<OrderDto> BuscarTodos()
        //{
        //	return _OrderDomain.BuscarTodos().ConvertToDto();
        //}

        ////Buscar Todos Con Dependencia
        //public IEnumerable<OrderDto> BuscarTodosConDependencia()
        //{
        //	return _OrderDomain.BuscarTodosConDependencia().ConvertToDto();
        //}

        ////Destruir
        //public OrderDto Destruir(int iDOrder)
        //{
        //	return _OrderDomain.Destruir(iDOrder).ConvertToDto();
        //}

        //// METODO BUSCAR ELIMINADOS
        //public  IEnumerable<OrderDto> BuscarEliminados()
        //{
        //	return _OrderDomain.BuscarEliminados().ConvertToDto();
        //}

        //// METODO ELIMINAR RANGO
        //public IEnumerable<OrderDto> EliminarRango (IEnumerable<int> listaIDOrder)
        //{
        //	return _OrderDomain.EliminarRango(listaIDOrder).ConvertToDto();
        //}

    }
}

