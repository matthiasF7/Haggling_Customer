namespace Haggling_Team_4
{
    public class MiscellaneousProduct : Product
    {
        private double _weightKg;
        private RarityEnum _rarity;

        public MiscellaneousProduct(int productId, string productName, decimal price, string productDescription,
            double weightKg, ProductTypeEnum productType, RarityEnum rarity)
            : base(productId, productName, price, productDescription, productType)
        {
            Weight = weightKg;
            _rarity = rarity;
        }

        public double Weight
        {
            get { return _weightKg; }
            set { if (value > 0) _weightKg = value; }
        }

        public override RarityEnum? Rarity => _rarity;
    }
}
