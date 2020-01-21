namespace VendingMachineApp
{
    public interface IVendingMachineFactory
    {
        IVendingMachine CreatePoundVendingMachine();
        IVendingMachine CreateDollarVendingMachine();
    }
}