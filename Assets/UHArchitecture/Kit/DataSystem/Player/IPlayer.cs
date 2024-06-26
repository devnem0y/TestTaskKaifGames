namespace UralHedgehog
{
    public interface IPlayer
    {
        public string Name { get; }
        public int ClickCount { get; }
        public int ClickMultiplier { get; }
    }
}