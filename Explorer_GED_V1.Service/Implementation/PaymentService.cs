using Explorer_GED_V1.Dal.Contracts;
using Explorer_GED_V1.Model;
using Explorer_GED_V1.Service.Contracts;
using System;
using System.Collections.Generic;

namespace Explorer_GED_V1.Service.Implementation
{
    public class PaymentService: IPaymentService
    {
        private readonly IPaymentDal _paymentDal;
        public PaymentService(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

       public List<PaymentModel> GetPendingPayments()
        {
            return _paymentDal.GetPendingPayments();
        }

        public bool CreatePayment(PaymentModel request)
        { 
            return _paymentDal.CreatePayment(request);
        } 

        public bool UpdatePayment(string docStatus, Guid paymentId)
        {
            return _paymentDal.UpdatePayment(docStatus, paymentId);
        }

        public List<PaymentModel> GetPaymentsByUser(Guid userId)
        {
            return _paymentDal.GetPaymentsByUser(userId);
        }

        public PaymentModel GetPaymentsByReference(string paymentRef)
        {
            return _paymentDal.GetPaymentsByReference(paymentRef);
        }
    }
}
