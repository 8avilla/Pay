using Auto.Pay.BusinessLogic.Entities;
using System;

namespace Auto.Pay.Application.Interfaces
{
    //MAPEADO Y GENERADO POR EXPRESS CODE
    public partial interface IPaymentReferenceApplication : IGenericApplication
	{
        EntityBusinessLogic Add(string paymentReferenceCode, DateTime creationDate, int amount, string paymentReferenceObject);
    }
}
