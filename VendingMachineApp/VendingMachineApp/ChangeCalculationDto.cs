using System.Collections.Generic;

namespace VendingMachineApp
{
    public class ChangeCalculationDto
    {
        public int RemainingAmountInCents { get; set; }
        public List<Coin> Coins { get; set; } = new List<Coin>();
    }
}
