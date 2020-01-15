using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineApp
{
    public class Money
    {
        public decimal CurrencyAmount { get; }
        public int CentAmount
        {
            get => Convert.ToInt32(CurrencyAmount * 100);
        }

        public Money(decimal currencyAmount)
        {
            CurrencyAmount = currencyAmount;
        }
    }
}
