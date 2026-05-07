using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Haggling_Team_4
{
    internal class NiceCustomer:Customer
    {
        public NiceCustomer(decimal startMoney, List<Product.ProductTypeEnum> likes, List<Product.ProductTypeEnum> dislikes) : base(startMoney, likes, dislikes)
        {

        }


        protected override bool DecideToBuy(Product product, decimal price, IVendor vendor)
        {
            if (price > Money)
            {
                return false;
            }

            if (product.Price * 0.8m >= price || (LikesIVendor(vendor) <4 && (product.Price * 0.85m >= price)) || (LikesIVendor(vendor) >= 4 && (product.Price * 0.9m >= price)))
            {
                Bought.Add(vendor, product);
                Money -= price;
                return true;
            }
            return false;
        }


        public override decimal NegotiatePrice(Product product, IVendor vendor, decimal price)
        {
            return base.NegotiatePrice(product, vendor, price) + 0.25m;
        }

        protected override int LikesIVendor(IVendor vendor) => base.LikesIVendor(vendor) + 1;


    }
}
