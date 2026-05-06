namespace Haggling_Team_4;

public abstract class Product
{
    public enum ProductTypeEnum 
    { 
        Fruit,
        Vegetable, 
        Dairy, 
        Meat, 
        Beverage, 
        Bakery, 
        Seafood, 
        Snack, 
        Frozen, 
        Household 
    }
        
    private int _productId;
    private decimal _price;


    public Product(int productId, string productName, decimal price, string productDescription, ProductTypeEnum productType)
    {
        _productId = ProductId;
        _price = price;
        ProductName = productName;
        ProductDescription = productDescription;
        ProductType = productType;
    }

    public int ProductId
    {
        get { return _productId; }
        set { if (value > 0) _productId = value; }
    }

    public decimal Price
    {
        get { return _price; }
        set { if (value > 0) _price = value; }
    }

    public ProductTypeEnum ProductType;

    public string ProductName;

    public string ProductDescription;

    public virtual RarityEnum? Rarity => null;

    public void ChangePrice(decimal newPrice)
    {
        if (newPrice > 0) _price = newPrice;
    }    
}
