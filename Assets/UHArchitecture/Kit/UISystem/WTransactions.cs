using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UralHedgehog.UI;

public class WTransactions : Widget<Transactions>
{
    [SerializeField] private Button _btnClose;
    [SerializeField] private Button _btnBuy;
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _lblMultiplier;
    [SerializeField] private TMP_Text _lblPrice;
    [SerializeField] private GameObject _marker;
    
    public override void Init(Transactions model)
    {
        base.Init(model);
        
        _btnClose.onClick.AddListener(Hide);
        _btnBuy.onClick.AddListener(Model.Buy);
        
        _btnBuy.interactable = Model.HasClicks;
        _marker.SetActive(!Model.HasClicks);

        _title.text = Model.Product.Title;
        _lblMultiplier.text = $"x{Model.Product.Multiplier}";
        _lblPrice.text = $"Купить за {Model.Product.Price} кликов";
    }
}