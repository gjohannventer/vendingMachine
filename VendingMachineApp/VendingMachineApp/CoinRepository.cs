using System.Collections.Generic;

namespace VendingMachineApp
{
    public class CoinRepository : ICoinRepository
    {
        public IEnumerable<Coin> GetDollarCoins()
        {
            return new Coin[] {
            new Coin
            {
                Amount = 5,
                Value = 25
            },
            new Coin
            {
                Amount = 0,
                Value = 10
            },
            new Coin
            {
                Amount = 5,
                Value = 5
            },
            new Coin
            {
                Amount = 5,
                Value = 1
            }
            };
        }

        public IEnumerable<Coin> GetPoundCoins()
        {
            return new Coin[] {
            new Coin
            {
                Amount = 5,
                Value = 50
            },
            new Coin
            {
                Amount = 5,
                Value = 20
            },
            new Coin
            {
                Amount = 5,
                Value = 10
            },
            new Coin
            {
                Amount = 5,
                Value = 5
            },
            new Coin
            {
                Amount = 5,
                Value = 2
            },
            new Coin
            {
                Amount = 10,
                Value = 1
            }
            };
        }
    }
}
