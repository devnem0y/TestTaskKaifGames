using UnityEngine;

public class PageShop : MonoBehaviour
{
    [SerializeField] private ItemProduct _itemProduct;
    [SerializeField] private Transform _content;

    private IShop _model;
    
    public void Init(IShop model)
    {
        _model = model;
        
        foreach (var product in _model.Storage.Products)
        {
            var item = Instantiate(_itemProduct, _content);
            var hasPurchaser = _model.Purchaser.Purchases.Contains(product.Id);
            item.Init(product, hasPurchaser, _model.SelectedProduct);
        }

        _model.Buy += OnBuy;
    }

    private void OnDestroy()
    {
        _model.Buy -= OnBuy;
    }

    private void OnBuy()
    {
        for (var i = 0; i < _content.childCount; i++)
        {
            var item = _content.GetChild(i).GetComponent<ItemProduct>();
            if (item.Id == _model.SelectProductId) item.ChangeState(true);
        }
    }
}
