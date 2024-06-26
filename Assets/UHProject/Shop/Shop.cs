using System;

public class Shop : IShop, IPurchasing
{
    public int SelectProductId { get; set; }
    public StorePurchases Storage { get; }
    public IPurchaser Purchaser { get; }
    public event Action buy;

    public Shop(StorePurchases storePurchases, IPurchaser purchaser)
    {
        Storage = storePurchases;
        Purchaser = purchaser;
    }

    public void Buy()
    {
        Purchaser.Purchase(Storage.GetProduct(SelectProductId));
        buy?.Invoke();
    }
}