using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapilnikTask2
{
    public interface IGoodsStore
    {
        int GetStored(Good good);
    }
    public class Good
    {
        public readonly string Name;
        public Good(string name)
        {
            Name = name;
        }
    }
    public class Shop
    {
        private readonly Warehouse _warehouse;
        public Shop(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }
        public Cart Cart()
        {
            return new Cart(_warehouse);
        }
    }

    public class Warehouse : IGoodsStore
    {
        Dictionary<Good, int> storedGoods = new Dictionary<Good, int>();
        public void Delive(Good good, int amount)
        {
            if (storedGoods.ContainsKey(good))
            {
                storedGoods[good] += amount;
            }
            else
            {
                storedGoods.Add(good, amount);
            }
        }
        public void DisplayAllGoods()
        {
            foreach (var storedGood in storedGoods)
            {
                Console.WriteLine($"{storedGood.Key.Name}: {storedGood.Value}");
            }
        }

        public int GetStored(Good good)
        {
            return storedGoods[good];
        }
    }

    public struct Order
    {
        public readonly string Paylink;
        public Order(string paylink)
        {
            Paylink = paylink;
        }
    }

    public class Cart : Dictionary<Good, int>
    {
        IGoodsStore _goodsStore;
        public Cart(IGoodsStore goodsStore)
        {
            _goodsStore = goodsStore;
        }
        public new void Add(Good good, int amount)
        {
            if (_goodsStore.GetStored(good) < amount)
                throw new ArgumentOutOfRangeException();
            if (ContainsKey(good))
            {
                this[good] += amount;
            }
            else
            {
                base.Add(good, amount);
            }
        }
        public Order Order()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var good in Keys)
            {
                stringBuilder.Append(good.Name);
                stringBuilder.Append(", ");
            }
            return new Order();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Good iPhone12 = new Good("IPhone 12");
            Good iPhone11 = new Good("IPhone 11");

            Warehouse warehouse = new Warehouse();

            Shop shop = new Shop(warehouse);

            warehouse.Delive(iPhone12, 10);
            warehouse.Delive(iPhone11, 1);

            //Вывод всех товаров на складе с их остатком

            Cart cart = shop.Cart();
            cart.Add(iPhone12, 4);
            cart.Add(iPhone11, 3); //при такой ситуации возникает ошибка так, как нет нужного количества товара на складе

            //Вывод всех товаров в корзине
            Console.WriteLine(cart.Order().Paylink);
        }
    }

    public static class ShopTests
    {
        [Test]
        public static void UseCase()
        {
            Good iPhone12 = new Good("IPhone 12");
            Good iPhone11 = new Good("IPhone 11");

            Warehouse warehouse = new Warehouse();

            Shop shop = new Shop(warehouse);

            warehouse.Delive(iPhone12, 10);
            warehouse.Delive(iPhone11, 1);

            //Вывод всех товаров на складе с их остатком


            Cart cart = shop.Cart();
            cart.Add(iPhone12, 4);
            cart.Add(iPhone11, 3); //при такой ситуации возникает ошибка так, как нет нужного количества товара на складе

            //Вывод всех товаров в корзине

            Console.WriteLine(cart.Order().Paylink);
        }
    }
}
