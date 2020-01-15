namespace VendingMachineApp
{
    public static class VendingMachineFactory
    {
        public static IVendingMachine CreatePoundVendingMachine()
        {
            return new VendingMachine(new[] { 50, 20, 10, 5, 2 , 1 }); // Always in order from maximun to minimum
        }


        public static IVendingMachine CreateDollarVendingMachine()
        {
            return new VendingMachine(new[] { 25, 10, 5, 1 });
        }
    }
}
