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
        protected List<Product.ProductTypeEnum> Likes { get; }
        protected List<Product.ProductTypeEnum> Dislikes { get; }
        protected Dictionary<Vendor, Product> Bought { get;  set; }

        protected abstract bool DecideToBuy(Product product, decimal price, Vendor vendor);

        public abstract decimal NegotiatePrice(Product product, Vendor vendor, decimal price);

        protected abstract int LikesVendor(Vendor vendor);

    }
}
