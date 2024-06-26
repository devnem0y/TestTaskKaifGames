using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StorePurchases", menuName = "Storage/Shop", order = 0)]
public class StorePurchases : ScriptableObject
{
    [SerializeField] private List<Product> _products;
    public List<Product> Products => _products;
}