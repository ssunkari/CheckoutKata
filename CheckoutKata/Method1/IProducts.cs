using System.Collections.Generic;

namespace Checkout.Method1
{
    public interface IProducts
    {
        IDictionary<string, decimal> products { get; }
    }
}