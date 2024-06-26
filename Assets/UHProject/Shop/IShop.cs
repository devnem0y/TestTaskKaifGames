using System;

public interface IShop
{
    int SelectProductId { get; set; }
    
    public StorePurchases Storage { get; }
    public IPurchaser Purchaser { get; }

    public event Action buy;
}