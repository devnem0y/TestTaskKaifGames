public class Transactions
{
    public Product Product { get; }
    public IPurchasing Purchasing { get; }
    public bool HasClicks { get; }
    
    public Transactions(Product product, IPurchasing purchasing, bool hasClicks)
    {
        Product = product;
        Purchasing = purchasing;
        HasClicks = hasClicks;
    }
}