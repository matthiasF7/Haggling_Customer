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

        protected abstract bool DecideToBuy(Product product, decimal price);

        public abstract decimal negotiatePrice(Product product, Vendor vendor, decimal price);

        protected abstract int likesVendor(Vendor vendor);

    }
}
