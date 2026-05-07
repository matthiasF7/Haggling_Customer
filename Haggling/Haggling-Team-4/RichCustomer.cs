using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Haggling_Team_4
{
    internal class RichCustomer:Customer
    {
        public RichCustomer(decimal startMoney, List<Product.ProductTypeEnum> likes, List<Product.ProductTypeEnum> dislikes) : base(startMoney * 1.25m, likes, dislikes)
        {

        }


        protected override bool DecideToBuy(Product product, decimal price, Vendor vendor)
        {
            if (price > Money)
            {
                return false;
            }

            if (product.Price * 0.9m >= price || (likesVendor(vendor) <4 && (product.Price * 0.95m >= price)) || (likesVendor(vendor) >= 4 && (product.Price * 0.99m >= price)))
            {
                Bought.Add(vendor, product);
                Money -= price;
                return true;
            }
            return false;
        }


        public override decimal negotiatePrice(Product product, Vendor vendor, decimal price)
        {
            return base.NegotiatePrice(product, vendor, price) + 0.5m;
        }

        protected override int likesVendor(Vendor vendor) => base.LikesVendor(vendor);


    }
}
