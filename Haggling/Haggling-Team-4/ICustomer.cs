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
        public abstract decimal GetMoney();
        protected abstract bool DecideToBuy(Product product, decimal price, Vendor vendor);

        public abstract decimal NegotiatePrice(Product product, Vendor vendor, decimal price);

        protected abstract int LikesVendor(Vendor vendor);

    }
}
