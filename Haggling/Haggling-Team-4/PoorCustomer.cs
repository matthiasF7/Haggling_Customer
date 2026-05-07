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


        protected override bool DecideToBuy(Product product, decimal price, IVendor vendor)
        {
            if (price > Money)
            {
                return false;
            }

            if (product.Price * 0.1m >= price || (LikesIVendor(vendor) < 4 && (product.Price * 0.15m >= price)) || (LikesIVendor(vendor) >= 4 && (product.Price * 0.2m >= price)))
            {
                Bought.Add(vendor, product);
                Money -= price;
                return true;
            }
            return false;
        }


        public override decimal NegotiatePrice(Product product, IVendor vendor, decimal price)
        {
            return base.NegotiatePrice(product, vendor, price) - 1.5m;
        }

        protected override int LikesIVendor(IVendor vendor) => base.LikesIVendor(vendor);


    }
}
