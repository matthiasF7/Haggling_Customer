using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Haggling_Team_4
{
    internal interface ICustomer
    {
        public decimal Money {  get; protected set; }
        public List<Product.ProductTypeEnum> Likes { get; }
        public List<Product.ProductTypeEnum> Dislikes { get; }
        public Dictionary<Vendor, Product> Bought { get; protected set; }

        protected abstract bool DecideToBuy(Product product, decimal prize);

        public abstract decimal negotiatePrize(Product product, Vendor vendor);

        private int likesVendor(Vendor vendor)
        {
            int count = 0;
            foreach(Vendor v in Bought.Keys)
            {
                if(v == vendor)
                {
                    count++;
                }
            }
            return count;
        }

    }
}
