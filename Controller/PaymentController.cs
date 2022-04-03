using BusinessRule_Engine.Repository.Interface;
using System;

namespace BusinessRule_Engine.Controller
{
    public class PaymentController
    {
        private readonly IPaymentModule _paymentModule;
        public PaymentController(IPaymentModule paymentModule)
        {
            _paymentModule = paymentModule;
        }

        /// <summary>
        /// Generate commision payment to agent
        /// </summary>
        /// <param name="paymentOption"></param>
        /// <returns>string</returns>
        public string CommisionPayment(string paymentOption)
        {
            string response = string.Empty;
            try
            {                
                response = _paymentModule.CommisionPayment(paymentOption);
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is an error occured with the message {0}", ex.Message);
            }
            return response;
        }
    }
}
