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
        public int Patience {  get; protected set; }

        public IVendor Vendor { get; protected set; } = null;

        public Product Product { get; protected set; } = null;

        public Customer(decimal startMoney, List<Product.ProductTypeEnum> likes, List<Product.ProductTypeEnum> dislikes)
        {
            Money = startMoney;
            Likes = likes;
            Dislikes = dislikes;
            Bought = new Dictionary<IVendor, Product>();
            Patience = 10;
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

        public int DecideToBuy(decimal price)
        {
            if (price > Money)
            {
                return 0;
            }

            if (Product.Price * 0.7m >= price || (LikesVendor(Vendor) < 4 && (Product.Price * 0.8m >= price)) || (LikesVendor(Vendor) >= 4 && (Product.Price * 0.85m >= price)))
            {
                Bought.Add(Vendor, Product);
                Money -= price;
                if (Likes.Contains(Product.ProductType))
                {
                    if (LikesVendor(Vendor)>0)
                    {
                        return 3;
                    }
                    else
                    {
                        return 2;
                    }

                }
                else
                {
                    return 1;
                }
            }
            return 0;
        }

        public decimal? NegotiatePrice(decimal price)
        {
            if (DecideToBuy(price) > 0)
            {
                return price; 
            }

            int vendorAffinity = LikesVendor(Vendor);
            bool likesProduct = Likes.Contains(Product.ProductType);
            bool dislikesProduct = Dislikes.Contains(Product.ProductType);

            decimal baseDiscount = 0.15m;
            baseDiscount -= vendorAffinity * 0.03m;
            if (likesProduct) baseDiscount -= 0.05m;
            if (dislikesProduct) baseDiscount += 0.07m;

            decimal counter = price * (1 - baseDiscount);

            if (counter < 0.1m) counter = 0.1m;
            if (counter > Money) counter = Money;

            return decimal.Round(counter, 2);
        }

        protected int LikesVendor(IVendor vendor)
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

        public void DecideOnProductToBuy(Product product, IVendor vendor)
        {
            Product = product;
            Vendor = vendor;
        }

        public decimal GetMoney()
        {
            return Money;
        }

        int ICustomer.LikesVendor(IVendor vendor)
        {
            return LikesVendor(vendor);
        }
    }
}
