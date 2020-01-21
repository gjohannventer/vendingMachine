using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace VendingMachineApp.Test
{
    [TestClass]
    public class VendingMachineTest
    {
        private IVendingMachine vendingMachine;
        [TestInitialize()]
        public void Startup()
        {
            var vendingMachineFactory = new VendingMachineFactory(new TestCoinRepository()); // should rather use a builder to initialize different states of an object;
            vendingMachine = vendingMachineFactory.CreateDollarVendingMachine();
        }
        
        [TestMethod]
        public void ShouldReturnCorrectAmountOfChange()
        {
            // arrange
            var expected = new int[] { 25 };
            var purchaseAmount = new Money(1.25m);
            var tenderAmount = new Money(1.50m);
            // act
            var change = vendingMachine.CalculateChange(purchaseAmount, tenderAmount);
            // assert
            expected.Should().BeEquivalentTo(change);
        }

        [TestMethod]
        public void ShouldReturnCorrectChangeWhenSomeCoinsAreOut()
        {
            var expected = new int[] { 25, 5, 5, 5 };
            var purchaseAmount = new Money(1.25m);
            var tenderAmount = new Money(1.65m);
            // act
            var change = vendingMachine.CalculateChange(purchaseAmount, tenderAmount);
            // assert
            expected.Should().BeEquivalentTo(change);
        }

    
        [TestMethod]
        public void ShouldFailWhenPurchaseAmountIsGreaterThanTenderAmount()
        {
            var purchaseAmount = new Money(1.65m);
            var tenderAmount = new Money(1.25m);

            Action act = () => vendingMachine.CalculateChange(purchaseAmount, tenderAmount);
            act.Should().Throw<Exception>().Where(e => e.Message.Contains("money"));           
        }
    }
}
