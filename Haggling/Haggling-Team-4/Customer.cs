using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Haggling_Team_4
{
    internal class Customer : ICustomer
    {

        public decimal Money { get; protected set; }
        public List<Product.ProductTypeEnum> Likes { get; }
        public List<Product.ProductTypeEnum> Dislikes { get; }
        public Dictionary<IVendor, Product> Bought { get; protected set; }

        public Customer(decimal startMoney, List<Product.ProductTypeEnum> likes, List<Product.ProductTypeEnum> dislikes)
        {
            Money = startMoney;
            Likes = likes;
            Dislikes = dislikes;
        }

        private static readonly Random Rng = new();

        public static Customer GetRandomCustomer(decimal startMoney, List<Product.ProductTypeEnum> likes, List<Product.ProductTypeEnum> dislikes)
        {
            return Rng.Next(0, 6) switch
            {
                0 => new RichCustomer(startMoney, likes, dislikes),
                1 => new NiceCustomer(startMoney, likes, dislikes),
                2 => new ChildCustomer(startMoney, likes, dislikes),
                3 => new AngryCustomer(startMoney, likes, dislikes),
                4 => new PoorCustomer(startMoney, likes, dislikes),
                5 => new ElderlyCustomer(startMoney, likes, dislikes),
                _ => new NiceCustomer(startMoney, likes, dislikes),
            };
        }

        protected override bool DecideToBuy(Product product, decimal price, IVendor vendor)
        {
            if (price > Money)
            {
                return false;
            }

            if (product.Price * 0.7m >= price || (LikesIVendor(vendor) < 4 && (product.Price * 0.8m >= price)) || (LikesIVendor(vendor) >= 4 && (product.Price * 0.85m >= price)))
            {
                Bought.Add(vendor, product);
                Money -= price;
                return true;
            }
            return false;
        }

        public override decimal NegotiatePrice(Product product, IVendor vendor, decimal price)
        {
            if (DecideToBuy(product, price, vendor))
            {
                return -1m;     //akzeptieren
            }

            int vendorAffinity = LikesIVendor(vendor);
            bool likesProduct = Likes.Contains(product.ProductType);
            bool dislikesProduct = Dislikes.Contains(product.ProductType);

            decimal baseDiscount = 0.15m;
            baseDiscount -= vendorAffinity * 0.03m;
            if (likesProduct) baseDiscount -= 0.05m;
            if (dislikesProduct) baseDiscount += 0.07m;

            decimal counter = price * (1 - baseDiscount);

            if (counter < 0.1m) counter = 0.1m;
            if (counter > Money) counter = Money;

            return decimal.Round(counter, 2);
        }

        protected override int LikesIVendor(IVendor vendor)
        {
            int count = 0;
            foreach (IVendor v in Bought.Keys)
            {
                if (v == vendor)
                {
                    count++;
                }
            }
            return count;
        }

        bool ICustomer.DecideToBuy(Product product, decimal price, IVendor vendor)
        {
           return DecideToBuy(product, price, vendor);
        }

        decimal ICustomer.NegotiatePrice(Product product, IVendor vendor, decimal price)
        {
            return NegotiatePrice(product, vendor, price);
        }

        int ICustomer.LikesIVendor(IVendor vendor)
        {
            return LikesIVendor(vendor);
        }

        public decimal GetMoney()
        {
            return Money;
        }
    }
}
