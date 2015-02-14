using System.Collections.Generic;

namespace Checkout
{
    public interface ILookUpPrice
    {
        IDictionary<string, decimal> GetPrice { get; }
    }
}