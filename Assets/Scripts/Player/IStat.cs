namespace TPP.Scripts
{
    public interface IStat
    {
        public string StatName { get; }
        public float StatValue { get; }
        public void Init(string statName, float statValue);
        public void Tick();
    }
}
