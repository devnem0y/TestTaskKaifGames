using System;

public interface IShop
{
    int SelectProductId { get; }
    
    public StorePurchases Storage { get; }
    public IPurchaser Purchaser { get; }

    public event Action Buy;

    void SelectedProduct(Product product);
}