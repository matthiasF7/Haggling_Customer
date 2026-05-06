using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Haggling_Team_4
{
    internal class Customer : ICustomer
    {
        public Customer(decimal startMoney, List<Product.ProductTypeEnum> Likes, List<Product.ProductTypeEnum> Dislikes) {
            
        }


        protected abstract bool DecideToBuy(Product product, decimal prize)
        {

        }

        public abstract decimal negotiatePrize(Product product, Vendor vendor)
        {

        }



    }


}
