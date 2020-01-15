using System.Collections.Generic;

namespace VendingMachineApp
{
    public interface IVendingMachine
    {
        public IEnumerable<int> CalculateChange(Money amount, Money received);
    }
}
