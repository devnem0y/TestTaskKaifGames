using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UralHedgehog;
using UralHedgehog.UI;

public class PMain : Widget<MainScreenController>
{
    private const int RND = 170;
    
    [SerializeField] private PageManager _pageManager;
    [SerializeField] private PageShop _shop;
    [SerializeField] private Button _btnClicker;

    [SerializeField] private Transform _parent;
    [SerializeField] private TMP_Text _flyText;

    public override void Init(MainScreenController model)
    {
        base.Init(model);
        
        _pageManager.Init();
        
        _shop.Init(Model.Shop);
        
        _btnClicker.onClick.AddListener(() =>
        {
            Model.Clicker.OnClick();
            ShowFlyText();
        });
    }

    private void ShowFlyText()
    {
        var position = _parent.position;
        var rndVector =  new Vector3( RndValue(position.x),  RndValue(position.y));
        var vfx = Instantiate(_flyText, position, Quaternion.identity, _parent);
        vfx.text = $"+{Model.Clicker.ClickForce}";
        vfx.transform.DOMove(rndVector, 3f, true);
        vfx.DOFade(0, 3);
        Destroy(vfx.gameObject, 3);
    }

    private static float RndValue(float value)
    {
        return value + Random.Range(-RND, RND);
    }
}
