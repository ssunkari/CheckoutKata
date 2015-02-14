using System.Collections.Generic;
using NUnit.Framework;

namespace Checkout.Test
{
    public class CheckoutKataMethod2Tests : ILookUpPrice,IDiscountRules
    {
        [Test]
        public void EmptyBasketMustReturnTotalPriceOfZero()
        {
            var target = new Checkout2(this,this);
            Assert.That(target.GetTotal(), Is.EqualTo(0));
        }
        [Test]
        public void ScanItemAMustGiveTotalOfFifty()
        {
            var target = new Checkout2(this,this);
            target.Scan("A");
            Assert.That(target.GetTotal(), Is.EqualTo(50));
        }

        [Test]
        public void ScanItemBMustGiveTotalOfThirty()
        {
            var target = new Checkout2(this,this);
            target.Scan("B");
            Assert.That(target.GetTotal(), Is.EqualTo(30));
        }

        [Test]
        public void ScanTwoItemBMustGiveTotalOfFifty()
        {
            var target = new Checkout2(this,this);
            target.Scan("B");
            target.Scan("B");
            Assert.That(target.GetTotal(), Is.EqualTo(50));
        }

        [Test]
        public void ScanThreeItemAMustGiveTotalOf130()
        {
            var target = new Checkout2(this,this);
            target.Scan("A");
            target.Scan("A");
            target.Scan("A");
            Assert.That(target.GetTotal(), Is.EqualTo(130));
        }

        [Test]
        public void ScanSixItemAMustGiveTotalOf260()
        {
            var target = new Checkout2(this, this);
            target.Scan("A");
            target.Scan("A");
            target.Scan("A");
            target.Scan("A");
            target.Scan("A");
            target.Scan("A");
            Assert.That(target.GetTotal(), Is.EqualTo(260));
        }


        [Test]
        public void ScanThreeItemAAndTwoBMustGiveTotalOf180()
        {
            var target = new Checkout2(this, this);
            target.Scan("A");
            target.Scan("A");
            target.Scan("A");
            target.Scan("B");
            target.Scan("B");
            Assert.That(target.GetTotal(), Is.EqualTo(180));
        }

        public IDictionary<string, decimal> GetPrice
        {
            get
            {
                return new Dictionary<string, decimal>
            {
               {"A",50},
               {"B",30},
               {"C",20}
            };
            }
        }

        public IDictionary<string, decimal> LookUp
        {
            get
            {
                return
                    new Dictionary<string, decimal>
                    {
                        {"A:3", 20},
                        {"B:2", 10}
                    };
            }
        }
    }
}