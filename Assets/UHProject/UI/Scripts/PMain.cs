using UnityEngine;
using UnityEngine.UI;
using UralHedgehog;
using UralHedgehog.UI;

public class PMain : Widget<MainScreenController>
{
    [SerializeField] private PageManager _pageManager;
    [SerializeField] private PageShop _shop;
    [SerializeField] private Button _btnClicker;

    public override void Init(MainScreenController model)
    {
        base.Init(model);
        
        _pageManager.Init();
        
        _shop.Init(Model.Shop);
        
        _btnClicker.onClick.AddListener(Model.Clicker.OnClick);
    }
}
