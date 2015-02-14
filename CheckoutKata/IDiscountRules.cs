using System.Collections.Generic;

namespace Checkout
{
    public interface IDiscountRules
    {
        IDictionary<string, decimal> LookUp { get;  }
    }
}