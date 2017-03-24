namespace MathCore.Care
{
    internal class BloodStream
    {
        int SystemInService;
        float _oxi;

        float FeroLevel = 0;
        float vB = 0;
        float Magniy = 0;

        public float OxiLevel
        {
            get
            {
                return _oxi;
            }
            set
            {
                _oxi = value;
            }
        }
        float glucose = 0;
        public BloodStream(int systems)
        {
            SystemInService = systems;
        }
        public float Upload(BloodComposition consumeResurse,int procentage)
        {
            switch (consumeResurse)
            {
                case BloodComposition.Oxi:
                    var buff = _oxi * (procentage)/100f;
                    _oxi *=  (100 - procentage)/100f;
                    return buff;
                default:
                    return 0;
            }
        }
    }
    public enum BloodComposition
    {
        Oxi
    }

}