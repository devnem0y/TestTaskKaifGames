using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "StorePurchases", menuName = "Storage/Shop", order = 0)]
public class StorePurchases : ScriptableObject
{
    [SerializeField] private List<Product> _products;
    public List<Product> Products => _products;

    public Product GetProduct(int Id)
    {
        return _products.FirstOrDefault(product => product.Id == Id);
    }
}