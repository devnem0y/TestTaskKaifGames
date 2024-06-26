using System.Collections.Generic;
using UralHedgehog;

public class Player : PlayerBase, IPlayer, IPurchaser
{
    public string Name { get; }
    public int ClickCount => GetCounter<Click>().Value;
    public int ClickMultiplier { get; private set; }
    public List<int> Purchases { get; }

    public Player(PlayerData data)
    {
        Data = data;

        Name = data.Name;

        var clickCount = new Click(data.ClickCount);
        CountersAdd(clickCount);

        ClickMultiplier = data.ClickMultiplier;
        Purchases = new List<int>(data.Purchases);
    }

    public override void Save()
    {
        Data = new PlayerData(Name, GetCounter<Click>().Value, ClickMultiplier, Purchases);
    }
    
    public void Purchase(Product product)
    {
        GetCounter<Click>().Withdraw(product.Price);
        Purchases.Add(product.Id);
        ClickMultiplier = product.Multiplier;
    }

    public bool HasClicks(int value)
    {
        return GetCounter<Click>().Available(value);
    }
}