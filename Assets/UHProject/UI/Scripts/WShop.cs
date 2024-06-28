using UnityEngine;
using UralHedgehog.UI;

public class WShop : Widget<IShop>
{
    [SerializeField] private ItemProduct _itemProduct;
    [SerializeField] private Transform _content;
    
    public override void Init(IShop model)
    {
        base.Init(model);

        foreach (var product in Model.Storage.Products)
        {
            var item = Instantiate(_itemProduct, _content);
            var hasPurchaser = Model.Purchaser.Purchases.Contains(product.Id);
            item.Init(product, hasPurchaser, Model.SelectedProduct);
        }

        Model.Buy += OnBuy;
    }

    private void OnDestroy()
    {
        Model.Buy -= OnBuy;
    }

    private void OnBuy()
    {
        for (var i = 0; i < _content.childCount; i++)
        {
            var item = _content.GetChild(i).GetComponent<ItemProduct>();
            if (item.Id == Model.SelectProductId) item.ChangeState(true);
        }
    }
}
