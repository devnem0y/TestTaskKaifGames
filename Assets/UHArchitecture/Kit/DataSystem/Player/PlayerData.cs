using System.Collections.Generic;

namespace UralHedgehog
{
    [System.Serializable]
    public struct PlayerData : IData
    {
        public string Name;
        public int ClickCount;
        public int ClickMultiplier;
        public List<int> Purchases;

        public PlayerData(PlayerData data)
        {
            Name = data.Name;
            ClickCount = data.ClickCount;
            Purchases = data.Purchases;
            ClickMultiplier = data.ClickMultiplier;
        }
    
        public PlayerData(string name, int clickCount, int clickMultiplier, List<int> purchases)
        {
            Name = name;
            ClickCount = clickCount;
            Purchases = purchases;
            ClickMultiplier = clickMultiplier;
        }
    }
}