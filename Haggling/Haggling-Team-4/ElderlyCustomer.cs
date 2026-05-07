using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Haggling_Team_4
{
    internal class ElderlyCustomer : Customer
    {

        public ElderlyCustomer(decimal startMoney, List<Product.ProductTypeEnum> likes, List<Product.ProductTypeEnum> dislikes) : base(startMoney , likes, dislikes)
        {

        }


        protected override bool DecideToBuy(Product product, decimal price, Vendor vendor)
        {
            return true;
        }


        public override decimal NegotiatePrice(Product product, Vendor vendor, decimal price)
        {
            return -1m;
        }

        protected override int LikesVendor(Vendor vendor) => base.LikesVendor(vendor) + 2;

    }
}
