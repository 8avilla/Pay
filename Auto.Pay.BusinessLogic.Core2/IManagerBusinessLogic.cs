﻿namespace Auto.Pay.BusinessLogic.Core
{
    public  interface IManagerBusinessLogic
    {
        OrderBusinessLogic Order { get; }
        PaymentReferenceBusinessLogic PaymentReference { get; }
    }
}
