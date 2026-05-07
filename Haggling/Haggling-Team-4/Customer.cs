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
        public Dictionary<Vendor, Product> Bought { get; protected set; }


        public Customer(decimal startMoney, List<Product.ProductTypeEnum> likes, List<Product.ProductTypeEnum> dislikes)
        {
            Money = startMoney;
            Likes = likes;
            Dislikes = dislikes;
            Bought = new Dictionary<Vendor, Product>();
        }


        protected virtual bool DecideToBuy(Product product, decimal price, Vendor vendor)
        {
            if (price > Money)
            {
                return false;
            }

            if (product.Price * 0.7m >= price || (likesVendor(vendor) < 4 && (product.Price * 0.8m >= price)) || (likesVendor(vendor) >= 4 && (product.Price * 0.85m >= price)))
            {
                Bought.Add(vendor, product);
                Money -= price;
                return true;
            }
            return false;
        }

        public virtual decimal negotiatePrice(Product product, Vendor vendor, decimal price)
        {
            if (DecideToBuy(product, price, vendor))
            {
                return -1m;     //akzeptieren
            }

            int vendorAffinity = likesVendor(vendor);
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

        protected virtual int likesVendor(Vendor vendor)
        {
            int count = 0;
            foreach (Vendor v in Bought.Keys)
            {
                if (v == vendor)
                {
                    count++;
                }
            }
            return count;
        }


    }


}
