using UnityEngine;
using UralHedgehog;
using UralHedgehog.UI;

public class WShop : Widget<Shop>
{
    [SerializeField] private ItemProduct _itemProduct;
    [SerializeField] private Transform _content;
    
    public override void Init(Shop model)
    {
        base.Init(model);

        foreach (var product in Model.Storage.Products)
        {
            var item = Instantiate(_itemProduct, _content);
            var hasPurchaser = Model.Purchaser.Purchases.Contains(product.Id);
            item.Init(product, hasPurchaser, SelectedItemProduct);
        }

        Model.buy += OnBuy;
    }

    private void OnDestroy()
    {
        Model.buy -= OnBuy;
    }

    private void SelectedItemProduct(int productId)
    {
        Model.SelectProductId = productId;
        
        var product = Model.Storage.GetProduct(productId);
        var hasClicks = Model.Purchaser.HasClicks(product.Price);
        var transactions = new Transactions(product, Model, hasClicks);
        
        Game.Instance.UIManager.OpenViewProduct(transactions);
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
