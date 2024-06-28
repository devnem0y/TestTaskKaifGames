using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemProduct : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private Image _icon;
    [SerializeField] private GameObject _purchasedMarker;

    public int Id { get; private set; }

    private bool _isPurchased;
    private Product _product;
    private Action<Product> _action;
    
    public void Init(Product product, bool isPurchased, Action<Product> action)
    {
        _product = product;
        
        _title.text = _product.Title;
        _icon.sprite = _product.Icon;
        
        Id = _product.Id;
        _action = action;
        
        ChangeState(isPurchased);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isPurchased) _action?.Invoke(_product);
    }

    public void ChangeState(bool isPurchased)
    {
        _isPurchased = isPurchased;
        _purchasedMarker.SetActive(_isPurchased);
    }
}