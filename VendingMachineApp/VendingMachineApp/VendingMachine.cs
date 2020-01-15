using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachineApp
{
    public class VendingMachine : IVendingMachine
    {
        public IEnumerable<int> CoinDenominations { get; }
        public VendingMachine(IEnumerable<int> coinDenominations)
        {
            CoinDenominations = coinDenominations;
        }

        public IEnumerable<int> CalculateChange(Money purchaseAmount, Money tenderAmount)
        {
            var changeCalculation = CoinDenominations.Aggregate(
                                                new ChangeCalculationDto { RemainingAmountInCents = tenderAmount.CentAmount - purchaseAmount.CentAmount },
                                                (changeCalculator, coinValue) =>
            {
                var coinValueIsBiggerThanRemainingAmount = coinValue > changeCalculator.RemainingAmountInCents;
                if (coinValueIsBiggerThanRemainingAmount)
                    return changeCalculator;

                var noMoreChangeIsNeeded = changeCalculator.RemainingAmountInCents == 0;
                if (noMoreChangeIsNeeded)
                    return changeCalculator;

                var amountOfCoins = CalculateAmountOfCoins(changeCalculator.RemainingAmountInCents, coinValue);
                var coins = GenerateCoinSequence(amountOfCoins, coinValue);
                changeCalculator.Coins.AddRange(coins);

                return new ChangeCalculationDto
                {
                    Coins = changeCalculator.Coins,
                    RemainingAmountInCents = changeCalculator.RemainingAmountInCents - (amountOfCoins * coinValue)
                };
            });

            return changeCalculation.Coins;
        }

        private int CalculateAmountOfCoins(int remainingAmount, int coinValue)
        {
            return remainingAmount / coinValue; ;
        }

        private IEnumerable<int> GenerateCoinSequence(int amountOfCoins, int coinValue)
        {
            return Enumerable.Range(1, amountOfCoins).Select(x => coinValue);
        }
    }
}
