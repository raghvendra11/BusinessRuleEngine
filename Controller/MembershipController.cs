using BusinessRule_Engine.Repository.Interface;
using BusinessRule_Engine.Utils;
using System;

namespace BusinessRule_Engine.Controller
{
    public class MembershipController
    {
        private readonly IMembershipModule _membershipModule;
        public MembershipController(IMembershipModule membershipModule)
        {
            _membershipModule = membershipModule;
        }

        /// <summary>
        /// Activate the membership
        /// </summary>
        /// <param name="paymentOption"></param>
        /// <returns>string</returns>
        public string ActivateMembership(string paymentOption)
        {
            string response = string.Empty;
            try
            {
                
                response = _membershipModule.ActivateMembership(paymentOption);
                EmailNotification.SendNotification("Your membership has been activated !", new string[] { "to@mail.com" }, new string[] { "bcc@mail.com" }, "from@mail.com");
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is an error occured with the message {0}",ex.Message);
            }
            return response;
        }

        /// <summary>
        /// Upgrade membership
        /// </summary>
        /// <param name="paymentOption"></param>
        /// <returns>string</returns>
        public string UpgradeMemberShip(string paymentOption)
        {
            string response = string.Empty;
            try
            {                
                response = _membershipModule.ActivateMembership(paymentOption);
                EmailNotification.SendNotification("Your membership has been upgraded !", new string[] {"to@mail.com" }, new string[] {"bcc@mail.com"}, "from@mail.com");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is an error occured with the message {0}", ex.Message);
            }
            return response;
        }
    }
}
