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

        public ElderlyCustomer(decimal startMoney, List<Product.ProductTypeEnum> likes, List<Product.ProductTypeEnum> dislikes) : base(startMoney, likes, dislikes)
        {

        }


        protected new int DecideToBuy(decimal price)
        {
            return 1;
        }


        public decimal? NegotiatePrice(Product product, IVendor vendor, decimal price)
        {
            return price;

        }

        protected new int LikesVendor(IVendor vendor) => base.LikesVendor(vendor) + 2;



    }
}
