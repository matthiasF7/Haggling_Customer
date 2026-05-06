namespace Haggling_Team_4;

public class DrinkProduct : Product
{
    private double _amountLiters;

    public DrinkProduct(int productId, string productName, decimal price, string productDescription,
        double amountLiters, DateOnly expirationDate, ProductTypeEnum productType)
        : base(productId, productName, price, productDescription, productType)
    {
        Liters = amountLiters;
        ExpirationDate = expirationDate;
    }

    public double Liters
    {
        get { return _amountLiters; }
        set { if (value >= 0) _amountLiters = value; }
    }

    public DateOnly ExpirationDate;
}
