using System.Collections.Generic;

namespace Checkout.Method1
{
    internal interface IPricingRules
    {
        decimal LookUp(List<string> scanner);
    }
}