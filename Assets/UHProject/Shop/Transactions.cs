using System;

public class Transactions
{
    public Product Product { get; }
    public bool HasClicks => _purchaser.HasClicks(Product.Price);
    
    private readonly IPurchaser _purchaser;
    private readonly Action _callback;
    
    public Transactions(Product product, IPurchaser purchaser, Action callback)
    {
        Product = product;
        _purchaser = purchaser;

        _callback = callback;
    }

    public void Buy()
    {
        if (!HasClicks) return;
        
        _purchaser.Purchase(Product);
        _callback?.Invoke();
    }
}