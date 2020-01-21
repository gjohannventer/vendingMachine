using System;
using System.Linq;

namespace VendingMachineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var vendingMachineFactory = new VendingMachineFactory(new CoinRepository());
            var vendingMachine = vendingMachineFactory.CreateDollarVendingMachine();
            var purchaseAmount = new Money(1.25m);
            var tenderAmount = new Money(2.15m);
            var changeReceived = vendingMachine.CalculateChange(purchaseAmount, tenderAmount);
            changeReceived.ToList().ForEach(change => Console.WriteLine(change));
        }
    }
}
