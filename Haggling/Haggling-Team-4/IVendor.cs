namespace Haggling_Team_4
{

    public interface IVendor
    {
        public List<Product>? GetProducts();

        public bool Negotiate(string productName, decimal offeredPrice, bool isChild);

        public Product? BuyProduct(string productName);

        public void UpdatePerishablePrices();

        public void AddProduct(Product product);

        public int GetPatience();
    }
}