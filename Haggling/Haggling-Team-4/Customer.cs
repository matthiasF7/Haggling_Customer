using System.Numerics;

namespace Haggling_Team_4
{
    internal class ChildCustomer : Customer
    {
        private const decimal ChildBudgetFactor = 0.8m;
        private const decimal ExtraTrustBonus = 0.05m; // Kinder vertrauen schneller

        public ChildCustomer(
            decimal startMoney,
            List<Product.ProductTypeEnum> likes,
            List<Product.ProductTypeEnum> dislikes)
            : base(startMoney * ChildBudgetFactor, likes, dislikes)
        {
        }

        protected override bool DecideToBuy(Product product, decimal price, Vendor vendor)
        {
            if (price > Money)
                return false;

            int affinity = LikesVendor(vendor);

            // Kinder sind weniger rational → akzeptieren schlechtere Deals
            decimal threshold =
                affinity >= 4 ? 0.9m :   // großzügiger als normaler Kunde
                affinity > 0 ? 0.85m :
                               0.75m;

            if (product.Price * threshold >= price)
            {
                RegisterPurchase(vendor, product, price);
                return true;
            }

            return false;
        }

        public override decimal NegotiatePrice(Product product, Vendor vendor, decimal price)
        {
            var result = base.NegotiatePrice(product, vendor, price);

            // Falls Gegenangebot kommt → Kinder handeln schlechter
            if (result != -1m)
            {
                result *= (1 + ExtraTrustBonus); // zahlen etwas mehr
                if (result > Money) result = Money;
            }

            return decimal.Round(result, 2);
        }

        protected override int LikesVendor(Vendor vendor)
        {
            // Kinder mögen Verkäufer schneller
            return base.LikesVendor(vendor) + 1;
        }

        protected void RegisterPurchase(Vendor vendor, Product product, decimal price)
        {
            if (!Bought.ContainsKey(vendor))
            {
                Bought[vendor] = new List<Product>();
            }

            Bought[vendor].Add(product);
            Money -= price;
        }
    }
}