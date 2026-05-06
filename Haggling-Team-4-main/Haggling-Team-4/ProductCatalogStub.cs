namespace Haggling_Team_4;


// This class is to be used by the vendor
public class ProductCatalog
{
    public ProductCatalog()
    {
        //
    }

    /// <summary>
    /// Adds Product to Catalog
    /// </summary>
    /// <param name="product">the product that needs to be added</param>
    public void AddProduct(Product product) 
    {
        //
    }

    /// <summary>
    /// Removes Product by ID
    /// </summary>
    /// <param name="id">id of product that needs to be removed</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public bool RemoveProduct(int id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Return Product with given ID
    /// </summary>
    /// <param name="id">ID of procuct</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Product GetProductById(int id) 
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns if Product is in Stock (in the Catalog)
    /// </summary>
    /// <param name="id">ID of procuct</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public bool IsProductInStock(int id) 
    {
        throw new NotImplementedException();
    }
}
