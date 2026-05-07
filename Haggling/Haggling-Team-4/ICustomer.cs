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
        protected abstract bool DecideToBuy(Product product, decimal price, IVendor vendor);

        public abstract decimal NegotiatePrice(Product product, IVendor vendor, decimal price);

        protected abstract int LikesIVendor(IVendor vendor);

    }
}
