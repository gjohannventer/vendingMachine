namespace VendingMachineApp
{
    public class VendingMachineFactory : IVendingMachineFactory
    {
        private readonly ICoinRepository _coinRepository;
        public VendingMachineFactory(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }
        public IVendingMachine CreatePoundVendingMachine()
        {
            return new VendingMachine(_coinRepository.GetPoundCoins()); // Always in order from maximum to minimum
        }

        public IVendingMachine CreateDollarVendingMachine()
        {
            return new VendingMachine(_coinRepository.GetDollarCoins());
        }
    }
}
