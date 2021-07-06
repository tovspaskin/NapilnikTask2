using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikTask2
{

    public class Cart
    {
        private Dictionary<Good, int> _goods = new Dictionary<Good, int>();
        private IGoodsStore _goodsStore;

        public Cart(IGoodsStore goodsStore)
        {
            _goodsStore = goodsStore;
        }

        public void Add(Good good, int amount)
        {
            if (_goodsStore.GetStoredGood(good) < amount)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (_goods.ContainsKey(good))
            {
                _goods[good] += amount;
            }
            else
            {
                _goods.Add(good, amount);
            }
        }

        public Order Order()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var good in _goods.Keys)
            {
                stringBuilder.Append(good.Name);
                stringBuilder.Append(", ");
            }

            return new Order(stringBuilder.ToString());
        }
    }
}
