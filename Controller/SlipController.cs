using BusinessRule_Engine.Repository.Interface;
using System;

namespace BusinessRule_Engine.Controller
{
    public class SlipController
    {
        private readonly ISlipGenerationModule _slipModule;
        public SlipController(ISlipGenerationModule slipModule)
        {
            _slipModule = slipModule;
        }

        /// <summary>
        ///  Generate a packing slip for shipping.
        /// </summary>
        /// <param name="paymentOptions"></param>
        /// <returns></returns>
        public string GenerateAPackagingSlipForShipping(string paymentOptions)
        {
            string response = string.Empty;
            try
            {                
                response = _slipModule.GenerateAPackagingSlipForShipping(paymentOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is an error occured with the message {0}", ex.Message);
            }
            return response;
        }

        /// <summary>
        /// Create a duplicate packing slip for the royalty department
        /// </summary>
        /// <param name="paymentOption"></param>
        /// <returns>string</returns>
        public string GenerateADuplicatePackingSlip(string paymentOptions)
        {
            string response = string.Empty;
            try
            {                
                response = _slipModule.GenerateADuplicatePackingSlip(paymentOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is an error occured with the message {0}", ex.Message);
            }
            return response;
        }

        /// <summary>
        /// Add a free First Aid video to packing slip
        /// </summary>
        /// <param name="paymentOption"></param>
        /// <returns>string</returns>
        public string FirstAidToSlip(string paymentOptions)
        {
            string response = string.Empty;
            try
            {                
                response = _slipModule.FirstAidToSlip(paymentOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is an error occured with the message {0}", ex.Message);
            }
            return response;
        }
    }
}
