using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public class DiscountHandler 
    {
        private readonly IDiscountRules _rules;

        public DiscountHandler(IDiscountRules rules)
        {
            _rules = rules;
        }

        public decimal GetDiscount(List<string> items)
        {
            decimal discount = 0;
            var itemGroupedBy = items.GroupBy(x => x).Select(item => new {Item = item.Key, Qty = item.Count()});
            var rule = string.Empty;
            foreach (var item in itemGroupedBy)
            {
                foreach (var key in _rules.LookUp.Keys.Where(key => key.Contains(item.Item)))
                {
                    rule = key;
                }
                if (!string.IsNullOrEmpty(rule))
                {
                    var deals = item.Qty / int.Parse(rule.Split(':')[1]);
                    discount += deals * _rules.LookUp[rule];
                }
            }
            return  discount;
        }
    }
}