using Auto.Pay.Application.Dtos;
using Auto.Pay.Application.Interfaces;
using Auto.Pay.BusinessLogic.Core;
using Auto.Pay.BusinessLogic.Entities;
using System;

namespace Auto.Pay.Application.Main
{
    //MAPEADO Y GENERADO POR EXPRESS CODE
    public class PaymentReferenceApplication : IPaymentReferenceApplication
    {
		private readonly IManagerBusinessLogic _managerBusinessLogic;
		public PaymentReferenceApplication(IManagerBusinessLogic managerBusinessLogic)
		{
			_managerBusinessLogic = managerBusinessLogic;
		}

		public EntityBusinessLogic Add(string paymentReferenceCode, DateTime creationDate, int amount, string paymentReferenceObject)
        {
            return _managerBusinessLogic.PaymentReference.Add(paymentReferenceCode, creationDate, amount, paymentReferenceObject);
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

