public class MainScreenController
{
    public IShop Shop { get; }
    public IClicker Clicker { get; }

    public MainScreenController(IShop shop, IClicker clicker)
    {
        Shop = shop;
        Clicker = clicker;
    }
}