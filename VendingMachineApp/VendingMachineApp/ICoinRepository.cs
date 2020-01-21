using System.Collections.Generic;

namespace VendingMachineApp
{
    public interface ICoinRepository : IRepository<Coin>
    {
        public IEnumerable<Coin> GetDollarCoins();
        public IEnumerable<Coin> GetPoundCoins();
    }
}