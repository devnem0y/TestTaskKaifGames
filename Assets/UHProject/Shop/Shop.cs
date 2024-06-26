using System;
using UralHedgehog;

public class Shop : IShop
{
    public int SelectProductId { get; private set; }
    public StorePurchases Storage { get; }
    public IPurchaser Purchaser { get; }
    
    public event Action Buy;

    public Shop(StorePurchases storePurchases, IPurchaser purchaser)
    {
        Storage = storePurchases;
        Purchaser = purchaser;
    }
    
    public void SelectedProduct(Product product)
    {
        SelectProductId = product.Id;
        var transactions = new Transactions(product, Purchaser, Buy);
        Game.Instance.UIManager.OpenViewTransactions(transactions);
    }
}