using System.Collections.Generic;

namespace Checkout.Method1
{
    public class Checkout
    {
        public Checkout(IProducts products)
        {
            _products = products;
        }

        private readonly IProducts _products;
        private readonly List<string> _scanner = new List<string>();
        private IPricingRules _pricingRules;

        public decimal GetTotal()
        {
            _pricingRules = new PricingRules(_products);
            return _pricingRules.LookUp(_scanner);
        }

        public void Scan(string sku)
        {
            _scanner.Add(sku);
        }
    }
}