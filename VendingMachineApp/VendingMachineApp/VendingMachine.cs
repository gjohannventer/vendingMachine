using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachineApp
{
    public class VendingMachine : IVendingMachine
    {
        public IEnumerable<Coin> CoinDenominations { get; }
        public VendingMachine(IEnumerable<Coin> coinDenominations)
        {
            CoinDenominations = coinDenominations;
        }

        public IEnumerable<int> CalculateChange(Money purchaseAmount, Money tenderAmount)
        {
            if (purchaseAmount.CurrencyAmount > tenderAmount.CurrencyAmount)
                throw new Exception("I need more money!");

            var seed = new ChangeCalculationDto { RemainingAmountInCents = tenderAmount.CentAmount - purchaseAmount.CentAmount };
            var changeCalculationResult = CoinDenominations.Aggregate(seed, DoChangeCalculationAccumulator);
            return changeCalculationResult.Coins.Select(coin => coin.Value);
        }

        private ChangeCalculationDto DoChangeCalculationAccumulator(ChangeCalculationDto changeCalculator, Coin coin)
        {
            var coinValueIsBiggerThanRemainingAmount = coin.Value > changeCalculator.RemainingAmountInCents;
            if (coinValueIsBiggerThanRemainingAmount)
                return changeCalculator;

            if (coin.Amount <= 0)
                return changeCalculator;

            var amountOfCoins = CalculateAmountOfCoins(changeCalculator.RemainingAmountInCents, coin.Value);
            var coins = Enumerable.Repeat(coin, amountOfCoins);
            changeCalculator.Coins.AddRange(coins);

            return new ChangeCalculationDto
            {
                Coins = changeCalculator.Coins,
                RemainingAmountInCents = changeCalculator.RemainingAmountInCents - (amountOfCoins * coin.Value)
            };
        }

        private int CalculateAmountOfCoins(int remainingAmount, int coinValue)
        {
            return remainingAmount / coinValue; ;
        }
    }
}
