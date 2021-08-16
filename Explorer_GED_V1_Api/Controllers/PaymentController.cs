using Explorer_GED_V1.Model;
using Explorer_GED_V1.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Explorer_GED_V1_Api.Controllers
{

    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("api/[controller]/GetPendingPayments")]
        public ActionResult GetPendingPayments()
        {
            return Ok(_paymentService.GetPendingPayments());
        }

        [HttpPost("api/[controller]/CreatePayment")]
        public IActionResult CreatePayment([FromBody] PaymentModel request)
        {
            return Ok(_paymentService.CreatePayment(request));
        }


        [HttpGet("api/[controller]/UpdatePayment/{docStatus}/{paymentId}")]
        public IActionResult UpdatePayment(string docStatus, Guid paymentId)
        {
            return Ok(_paymentService.UpdatePayment(docStatus, paymentId));
        }

        [HttpGet("api/[controller]/GetPaymentsByUser/{agentId}")]
        public IActionResult UpdatePayment(Guid agentId)
        {
            return Ok(_paymentService.GetPaymentsByUser(agentId));
        }
         
        [HttpGet("api/[controller]/GetPaymentsByReference/{paymentReference}")]
        public IActionResult GetPaymentsByReference(string paymentReference)
        {
            return Ok(_paymentService.GetPaymentsByReference(paymentReference));
        }
    }
}
