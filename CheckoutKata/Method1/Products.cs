using System.Collections.Generic;
using Checkout.Method1;

namespace Checkout
{
    public class Products : IProducts
    {
        private IDictionary<string, decimal> _products;

        public IDictionary<string, decimal> products
        {
            get { return _products; }
            private set
            {
                _products = value;
                _products = new Dictionary<string, decimal>
                {
                    {"A:1",50},
                    {"B:1",30},
                    {"A:3",130}
                };
            }
        }
    }
}