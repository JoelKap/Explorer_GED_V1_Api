using Explorer_GED_V1.Model;
using System;
using System.Collections.Generic;

namespace Explorer_GED_V1.Service.Contracts
{
    public interface IPaymentService
    {
        List<PaymentModel> GetPendingPayments();
        bool CreatePayment(PaymentModel request); 
        bool UpdatePayment(string docStatus, Guid paymentId, string comment); 
        List<PaymentModel> GetPaymentsByUser(Guid agentId);
        PaymentModel GetPaymentsByReference(string paymentRef);
    }
}
 