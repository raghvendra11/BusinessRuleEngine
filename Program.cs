using System;
using System.Threading.Tasks;
using BusinessRule_Engine.Controller;
using BusinessRule_Engine.Repository;
using BusinessRule_Engine.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BusinessRule_Engine
{

    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
             services.AddTransient<IMembershipModule, MembershipModule>()
            .AddTransient<IPaymentModule, PaymentModule>()
            .AddTransient<IMembershipModule, MembershipModule>())
            .Build();
            var input = Console.ReadLine();
            GetInputBasedControllerExecution(host.Services, input);    

            await host.RunAsync();
        }

        static void GetInputBasedControllerExecution(IServiceProvider services,string input)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            //for membership module //other module will follow the same approach hence not called here
            if (!string.IsNullOrEmpty(input) && (string.Equals(input,"membership",StringComparison.OrdinalIgnoreCase) || string.Equals(input, "membershipupgrade", StringComparison.OrdinalIgnoreCase)))
            {
                MembershipController membershipCntrl = provider.GetRequiredService<MembershipController>();
                if (string.Equals(input, "membership", StringComparison.OrdinalIgnoreCase))
                {
                    membershipCntrl.UpgradeMemberShip("MemberShipUpgrade");
                }
                if (string.Equals(input, "membershipupgrade", StringComparison.OrdinalIgnoreCase))
                {
                    membershipCntrl.UpgradeMemberShip("MemberShipUpgrade");
                } 
            }

            Console.WriteLine();
        }
    }
}




