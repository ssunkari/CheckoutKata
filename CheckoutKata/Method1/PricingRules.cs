using System.Collections.Generic;
using System.Linq;
using Checkout.Method1;

namespace Checkout
{
    public class PricingRules : IPricingRules
    {
        private readonly IProducts _products;

        public PricingRules(IProducts products)
        {
            _products = products;
        }

        public decimal LookUp(List<string> scanner)
        {
            decimal total = 0;
            var items = scanner.GroupBy(x => x).Select(x => new { item = x.Key, count = x.Count() });

            foreach (var item in items)
            {
                var qty = item.count;
                while (qty > 0)
                {
                    if (item.item == "A")
                    {
                        var deals = item.count / 3;
                        total += deals * _products.products[string.Format("{0}:{1}", item.item, 3)];
                        qty -= deals * 3;
                    }
                    if (item.item == "B")
                    {
                        var deals = item.count / 2;
                        total += deals * _products.products[string.Format("{0}:{1}", item.item, 2)];
                        qty -= deals * 2;
                    }
                    for (int i = 1; i <= qty; i++,qty--)
                    {
                        total += _products.products.ContainsKey(string.Format("{0}:{1}", item.item, i)) ?
                            _products.products[string.Format("{0}:{1}", item.item, i)] : 0;
                    }
                }
            }

            return total;
        }


    }
}