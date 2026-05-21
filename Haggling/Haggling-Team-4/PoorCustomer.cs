using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Haggling_Team_4
{
    internal class PoorCustomer : Customer
    {

        public PoorCustomer(decimal startMoney, List<Product.ProductTypeEnum> likes, List<Product.ProductTypeEnum> dislikes) : base(startMoney * 0.2m, likes, dislikes)
        {

        }


        protected new int DecideToBuy(decimal price)
        {
            if (price > Money)
            {
                return 0;
            }

            if (Product.Price * 0.1m >= price || (LikesVendor(Vendor) < 4 && (Product.Price * 0.15m >= price)) || (LikesVendor(Vendor) >= 4 && (Product.Price * 0.2m >= price)))
            {
                Bought.Add(Vendor, Product);
                Money -= price;
                if (Likes.Contains(Product.ProductType))
                {
                    if (LikesVendor(Vendor) > 0)
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


        public decimal? NegotiatePrice(Product product, IVendor vendor, decimal price)
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

            return decimal.Round(counter, 2) - 0.5m;

        }

        protected new int LikesVendor(IVendor vendor) => base.LikesVendor(vendor);


    }
}
