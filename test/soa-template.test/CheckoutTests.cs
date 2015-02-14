using System.Collections.Generic;
using Checkout.Method1;
using NUnit.Framework;

namespace Checkout.Test
{
    public class CheckoutTests : IProducts
    {

        [Test]
        public void TotalPriceOfEmptyCardIsZero()
        {
            var checkout = new Method1.Checkout(this);
            Assert.That(checkout.GetTotal(), Is.EqualTo(0));
        }
        [Test]
        public void WhenItemAisScannedThenTotalPriceIs50()
        {
            var checkout = new Method1.Checkout(this);
            checkout.Scan("A");
            Assert.That(checkout.GetTotal(), Is.EqualTo(50));
        }
        [Test]
        public void WhenTwoItemsOfAAreScannedThenTotalPriceIs100()
        {
            var checkout = new Method1.Checkout(this);
            checkout.Scan("A");
            checkout.Scan("A");
            Assert.That(checkout.GetTotal(), Is.EqualTo(100));
        }
        [Test]
        public void WhenItemsOfBIsScannedThenTotalPriceIs30()
        {
            var checkout = new Method1.Checkout(this);
            checkout.Scan("B");
            Assert.That(checkout.GetTotal(), Is.EqualTo(30));
        }
        [Test]
        public void WhenTwoItemsOfBAreScannedThenTotalPriceIs60()
        {
            var checkout = new Method1.Checkout(this);
            checkout.Scan("B");
            checkout.Scan("B");
            Assert.That(checkout.GetTotal(), Is.EqualTo(50));
        }

        [Test]
        public void WhenTwoItemsOfBAndOneAAreScannedThenTotalPriceIs110()
        {
            var checkout = new Method1.Checkout(this);
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("A");
            Assert.That(checkout.GetTotal(), Is.EqualTo(100));
        }

        [Test]
        public void WhenThreeItemsOfAAreScannedThenTotalPriceIs130()
        {
            var checkout = new Method1.Checkout(this);
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            Assert.That(checkout.GetTotal(), Is.EqualTo(130));
        }

        public IDictionary<string, decimal> products
        {
            get
            {
                return new Dictionary<string, decimal>
                 {
                {"A:1",50},
                {"B:1",30},
                {"A:3",130},
                {"B:2",50},
                {"C:1",20}
            };
            }
        }
    }
}