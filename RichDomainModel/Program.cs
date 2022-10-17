using System;
using System.Linq;
using RichDomainModel.Application.PaymentApplications;

namespace RichDomainModel
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var paymentFactory = PaymentFactory.CreatePayment("123", 5696, "fadi", DateTime.UtcNow);

            Console.WriteLine(paymentFactory.StatusHistory.Last().Status);
            Console.WriteLine(paymentFactory.CurrentStatus.Status);
            paymentFactory.WaitingAuth(DateTime.UtcNow, "mario");
            Console.WriteLine(paymentFactory.StatusHistory.Last().Status);
            Console.WriteLine(paymentFactory.CurrentStatus.Status);
            Console.WriteLine("Hello World!");
        }
    }
}
