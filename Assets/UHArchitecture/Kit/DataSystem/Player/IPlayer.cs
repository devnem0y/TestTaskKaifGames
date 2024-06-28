using System;

namespace UralHedgehog
{
    public interface IPlayer
    {
        public string Name { get; }
        public int Level{ get; }
        public int ClickNextLevel { get; }
        public int ClickCount { get; }
        public int ClickMultiplier { get; }
        
        public event Action ChangeClickCount;
        public event Action ChangeLevel;
    }
}