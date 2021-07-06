using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikTask2
{

    public class Warehouse : IGoodsStore
    {
        private readonly Dictionary<Good, int> _storedGoods = new Dictionary<Good, int>();

        public void Delive(Good good, int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException();
            }

            if (_storedGoods.ContainsKey(good))
            {
                _storedGoods[good] += amount;
            }
            else
            {
                _storedGoods.Add(good, amount);
            }
        }

        public void DisplayAllGoods()
        {
            foreach (var storedGood in _storedGoods)
            {
                Console.WriteLine($"{storedGood.Key.Name}: {storedGood.Value}");
            }
        }

        public int GetStoredGood(Good good)
        {
            return _storedGoods[good];
        }
    }
}
