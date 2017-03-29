namespace Health
{
    internal interface IBodySystem
    {
        float bloodVolume { get; set; }
        void Update();
    }
}