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
    private Action<int> _action;
    
    public void Init(Product product, bool isPurchased, Action<int> action)
    {
        _title.text = product.Title;
        _icon.sprite = product.Icon;
        
        Id = product.Id;
        _action = action;
        
        ChangeState(isPurchased);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isPurchased) _action?.Invoke(Id);
    }

    public void ChangeState(bool isPurchased)
    {
        _isPurchased = isPurchased;
        _purchasedMarker.SetActive(_isPurchased);
    }
}