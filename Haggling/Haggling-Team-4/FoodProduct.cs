namespace Haggling_Team_4;

public enum Allergens
{
    Gluten,
    Milch,
    Eier,
    Nüsse, 
    Fleisch, 
    Krebstiere
}

public class FoodProduct : Product
{
    private double _weightKg;

    public FoodProduct(int productId, string productName, decimal price, string productDescription,
        double weightKg, DateOnly expirationDate, List<Allergens> allergens, ProductTypeEnum productType)
        : base(productId, productName, price, productDescription, productType)
    {
        Weight = weightKg;
        ExpirationDate = expirationDate;
        Allergens = allergens;
    }

    public double Weight
    {
        get { return _weightKg; }
        set { if (value > 0) _weightKg = value; }
    }

    public List<Allergens> Allergens;

    public DateOnly ExpirationDate;
}
