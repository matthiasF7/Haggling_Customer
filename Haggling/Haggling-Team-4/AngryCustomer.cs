using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Haggling_Team_4
{
    internal class AngryCustomer : Customer
    {
        public AngryCustomer(decimal startMoney, List<Product.ProductTypeEnum> likes, List<Product.ProductTypeEnum> dislikes) : base(startMoney, likes, dislikes)
        {

        }


        protected override bool DecideToBuy(Product product, decimal price, IVendor vendor)
        {
            if (price > Money)
            {
                return false;
            }

            if (product.Price * 0.65m >= price || (LikesVendor(vendor) <4 && (product.Price * 0.7m >= price)) || (LikesVendor(vendor) >= 4 && (product.Price * 0.75m >= price)))
            {
                Bought.Add(vendor, product);
                Money -= price;
                return true;
            }
            return false;
        }


        public override decimal NegotiatePrice(Product product, IVendor vendor, decimal price)
        {
            return base.NegotiatePrice(product, vendor, price) - 0.5m;
        }

        protected override int LikesVendor(IVendor vendor) => base.LikesVendor(vendor) - 1;


    }
}