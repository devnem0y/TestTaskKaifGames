public class MainScreenController
{
    public IShop Shop { get; }

    public MainScreenController(IShop shop)
    {
        Shop = shop;
    }
}