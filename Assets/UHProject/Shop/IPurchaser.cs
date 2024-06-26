using System.Collections.Generic;

public interface IPurchaser
{
    public List<int> Purchases { get; }
    
    void Purchase(Product product);

    bool HasClicks(int value);
}