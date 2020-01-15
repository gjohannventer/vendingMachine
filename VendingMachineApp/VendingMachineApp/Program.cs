using System;

namespace VendingMachineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var vendingMachine = VendingMachineFactory.CreateDollarVendingMachine();
            var purchaseAmount = new Money(1.25m);
            var tenderAmount = new Money(2.15m);
            vendingMachine.CalculateChange(purchaseAmount, tenderAmount);
        }
    }
}
