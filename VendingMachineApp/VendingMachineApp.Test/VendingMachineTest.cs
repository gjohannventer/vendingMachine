using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace VendingMachineApp.Test
{
    [TestClass]
    public class VendingMachineTest
    {
        [TestMethod]
        public void ShouldReturnCorrectAmountOfChange()
        {
            // arrange
            var expected = new int[] { 25, 10, 5 };
            var vendingMachine = VendingMachineFactory.CreateDollarVendingMachine();
            var purchaseAmount = new Money(1.25m);
            var tenderAmount = new Money(1.65m);
            // act
            var change = vendingMachine.CalculateChange(purchaseAmount, tenderAmount);
            // assert
            //Assert.AreEqual(expected, change.ToArray()); // Still need to implement the correct assert for testing two collection types
        }
    }
}
