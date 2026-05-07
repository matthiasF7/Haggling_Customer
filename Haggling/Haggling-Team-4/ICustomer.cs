using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Haggling_Team_4
{
    public interface ICustomer
    {
        public decimal GetMoney();

        public void DecideOnProductToBuy(Product product, IVendor vendor);

        public  decimal NegotiatePrice(string productName, decimal price);

        public int DecideToBuy(string productName, decimal price);

        public int LikesVendor(IVendor vendor);
    }
}
