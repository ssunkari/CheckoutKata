using System.Collections.Generic;

namespace Checkout
{
    public class Checkout2
    {
        private readonly List<string> _items = new List<string>();
        private readonly ILookUpPrice _products;
        private decimal _total;
        private readonly IDiscountRules _discountRules;

        public Checkout2(ILookUpPrice lookUpPrice, IDiscountRules discountRules)
        {
            _products = lookUpPrice;
            _discountRules = discountRules;
        }


        public decimal GetTotal()
        {
            var discountHandler = new DiscountHandler(_discountRules);
            foreach (var item in _items)
            {
                _total += _products.GetPrice[item];
            }
            _total -= discountHandler.GetDiscount(_items);

            return _total;
        }

        public void Scan(string sku)
        {
            _items.Add(sku);
        }
    }
}