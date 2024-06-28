using UralHedgehog;

public class ClickerController
{
    public IPlayer Player { get; }
    public IClicker Clicker { get; }
    
    public ClickerController(Player player)
    {
        Player = player;
        Clicker = player;
    }
}