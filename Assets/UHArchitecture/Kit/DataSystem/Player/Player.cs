using System;
using System.Collections.Generic;
using UralHedgehog;

public class Player : PlayerBase, IPlayer, IPurchaser, IClicker
{
    private const int MAX_NEXT_LEVEL_START = 10;
    
    public string Name { get; }
    public int Level { get; private set; }
    public int ClickNextLevel { get; private set; }
    public int ClickCount => GetCounter<Click>().Value;
    public int ClickMultiplier { get; private set; }
    public List<int> Purchases { get; }
    public int ClickForce { get; private set; } = 1;

    public event Action ChangeClickCount;
    public event Action ChangeLevel;

    public Player(PlayerData data)
    {
        Data = data;

        Name = data.Name;
        Level = data.Level;
        
        ClickNextLevel = Level > 1 ? data.ClickNextLevel : MAX_NEXT_LEVEL_START;

        var clickCount = new Click(data.ClickCount);
        CountersAdd(clickCount);

        ClickMultiplier = data.ClickForce;
        Purchases = new List<int>(data.Purchases);
        
        SetClickForce();

        GetCounter<Click>().Change += () => { ChangeClickCount?.Invoke(); };
    }

    public override void Save()
    {
        Data = new PlayerData(Name, 
            GetCounter<Click>().Value, 
            ClickForce, Level, 
            ClickNextLevel, 
            Purchases);
    }
    
    public void Purchase(Product product)
    {
        GetCounter<Click>().Withdraw(product.Price);
        Purchases.Add(product.Id);
        ClickMultiplier = product.Multiplier;
        
        SetClickForce();
    }

    public bool HasClicks(int value)
    {
        return GetCounter<Click>().Available(value);
    }

    public void OnClick()
    {
        GetCounter<Click>().Add(ClickForce);

        if (ClickCount < ClickNextLevel) return;
        
        Level++;
        ClickNextLevel *= 2;
        GetCounter<Click>().Zero();
        ChangeLevel?.Invoke();
    }

    private void SetClickForce()
    {
        ClickForce *= ClickMultiplier;
    }
}