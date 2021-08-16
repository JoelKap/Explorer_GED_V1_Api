﻿using Explorer_GED_V1.Model;
using System;
using System.Collections.Generic;

namespace Explorer_GED_V1.Dal.Contracts
{
    public interface IPaymentDal
    {
        List<PaymentModel> GetPendingPayments();
        bool CreatePayment(PaymentModel request);
        bool UpdatePayment(string docStatus, Guid paymentId);
        List<PaymentModel> GetPaymentsByUser(Guid agentId);
        PaymentModel GetPaymentsByReference(string paymentRef);
    }
}
 