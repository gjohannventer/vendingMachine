using System.Collections.Generic;

namespace VendingMachineApp
{
    public class ChangeCalculationDto
    {
        public int RemainingAmountInCents { get; set; }
        public List<int> Coins { get; set; } = new List<int>();
    }
}
