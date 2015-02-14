using System.Collections.Generic;

namespace Checkout
{
    public class DiscountRules : IDiscountRules
    {
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