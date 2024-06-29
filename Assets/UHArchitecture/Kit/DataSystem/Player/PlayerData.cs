using System.Collections.Generic;

namespace UralHedgehog
{
    [System.Serializable]
    public struct PlayerData : IData
    {
        public string Name;
        public int Level;
        public int ClickNextLevel;
        public int ClickCount;
        public int ClickForce;
        public List<int> Purchases;

        public PlayerData(PlayerData data)
        {
            Name = data.Name;
            ClickCount = data.ClickCount;
            Purchases = data.Purchases;
            ClickForce = data.ClickForce;
            ClickNextLevel = data.ClickNextLevel;
            Level = data.Level;
        }
    
        public PlayerData(string name, int clickCount, int clickForce, int level, int clickNextLevel, List<int> purchases)
        {
            Name = name;
            ClickCount = clickCount;
            Purchases = purchases;
            ClickForce = clickForce;
            ClickNextLevel = clickNextLevel;
            Level = level;
        }
    }
}