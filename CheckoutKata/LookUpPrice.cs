using System.Collections.Generic;

namespace Checkout
{
    public class LookUpPrice : ILookUpPrice
    {
        private readonly IDictionary<string, decimal> _itemList =

            new Dictionary<string, decimal>
            {
                { "A",50},
                {"B",30},
                {"C",20}
            };

        public IDictionary<string, decimal> GetPrice
        {
            get { return _itemList; }
        }


    }
}