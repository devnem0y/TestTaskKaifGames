using System;
using UnityEngine;

[Serializable]
public class Product
{
    [SerializeField] private string _title;
    public string Title => _title;
    
    [SerializeField] private int _id;
    public int Id => _id;
    
    [SerializeField] private int _multiplier;
    public int Multiplier => _multiplier;
    
    [SerializeField] private Sprite _icon;
    public Sprite Icon => _icon;
    
    [SerializeField] private int _price;
    public int Price => _price;
}