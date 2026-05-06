
        using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Haggling_Team_4
    {
        internal class ChildCustomer : Customer
        {
            public ChildCustomer(decimal startMoney, List<Product.ProductTypeEnum> likes, List<Product.ProductTypeEnum> dislikes) : base(startMoney*0.8m, likes, dislikes)
            {

            }


            protected override bool DecideToBuy(Product product, decimal price, Vendor vendor)
            {
                if (price > Money)
                {
                    return false;
                }

                if (product.Price*0.7m >= price || (likesVendor(vendor) <4 && (product.Price*0.8m >= price)) || (likesVendor(vendor) >= 4 && (product.Price*0.9m >= price)))
                {
                    Bought.Add(vendor, product);
                    Money-=price;
                    return true;
                }
                return false;
            }


            public override decimal negotiatePrice(Product product, Vendor vendor, decimal price)
            {
                return base.negotiatePrice(product, vendor, price);
            }

            protected override int likesVendor(Vendor vendor) => base.likesVendor(vendor) + 1;


        }
    }

}
