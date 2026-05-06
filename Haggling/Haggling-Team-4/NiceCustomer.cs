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


        protected override bool DecideToBuy(Product product, decimal price, Vendor vendor)
        {
            if (price > Money)
            {
                return false;
            }

            if (product.Price * 0.8m >= price || (likesVendor(vendor) <4 && (product.Price * 0.85m >= price)) || (likesVendor(vendor) >= 4 && (product.Price * 0.9m >= price)))
            {
                Bought.Add(vendor, product);
                Money -= price;
                return true;
            }
            return false;
        }


        public override decimal negotiatePrice(Product product, Vendor vendor, decimal price)
        {
            return base.negotiatePrice(product, vendor, price) + 0.25m;
        }

        protected override int likesVendor(Vendor vendor) => base.likesVendor(vendor) + 1;


    }
}
