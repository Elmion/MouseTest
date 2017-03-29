using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health
{
    class BloodStream
    {

        float _power_pulse = 10;
        float _pulseBMP = 60;

        public BloodStream(List<IBodySystem> systems)
        {
            var totalBloodVolume = 0f;
            for (int i = 0; i < systems.Count; i++)
            {
                totalBloodVolume += systems[i].bloodVolume;
            }
        }
        private float Pressure(int Distance)//Давление
        {
            return 0;
        }
        public void Update()
        {

        }
        void SateBlood()
        {

        }
        //private float Pulse()
        //{

        //}
    }
   public  class Heart
    {
        public Action Tuk;
        float _pressure = 120;
        float Wearout = 0;
        float _currentBMP = 60;

        float TimeDeltaTuk = 0; //Время текущего цикла
        float TimeTukCicle; //максимальное время цикла

        private const float NORMAL_REDUCE_PRESSURE = 0.3f;// 2.5746f;
        private const int MAX_BPM = 200;
        private const int MIN_BPM = 20;
        private const float INCRIMENT_BPM = 5f;
        public float Power_Trust { get; set; }
        public float TargetРressure { get; set; }
        public float CurrentBPM { get { return _currentBMP; }}
        public float CurrentPressure { get { return _pressure; } }
        public Heart()
        {
            TimeTukCicle = 60 * 10000000 / _currentBMP;
            Power_Trust = 2;
            TargetРressure = 120;
        }
        public void Acceleration(Power ChangePower)
        {

            _currentBMP += 5f * (float)ChangePower / 100f;
        }
        public void Deceleration(Power ChangePower)
        {
            _currentBMP -= 5f * (float)ChangePower / 100f;
        }
        public void Update(long deltaTime)
        {
            TimeDeltaTuk -= deltaTime;
            ChangeBeat();
            //var d = GetDemensionFunction(10 *_pressure / 180f) * NORMAL_REDUCE_PRESSURE; 
            _pressure -= GetDemensionFunction(10 * _pressure / 180f) * NORMAL_REDUCE_PRESSURE;//естественное давления замедление
        }
        private float GetDemensionFunction(float x)
        {
            return (float)( 1 - Math.Exp(-x / 2));
        }
        private void ChangeBeat()
        {
            TimeTukCicle = 60 *10000000/ _currentBMP;
            if (TimeDeltaTuk < 0)
            {
                Tuk();
                _pressure += Power_Trust;
                TimeDeltaTuk += TimeTukCicle;
                CorrectPressure();
            }
        }
        void CorrectPressure()
        {
            var odds = Math.Abs(TargetРressure - _pressure);
            Power ChangePower = Power.VeryEasy;
            if (0 < odds && odds <= 1) ChangePower = Power.VeryEasy;
            if (1 < odds && odds <= 2) ChangePower = Power.Easy;
            if (3 < odds && odds <= 4) ChangePower = Power.Medium;
            if (4 < odds && odds <= 6) ChangePower = Power.Hard;
            if (6 < odds && odds <= 10) ChangePower = Power.Critical;
            if (10 < odds) ChangePower = Power.Maximum;

            if (TargetРressure > _pressure) Acceleration(ChangePower);
            if (TargetРressure < _pressure) Deceleration(ChangePower);
        }

    }
    public enum Power : int
    {
        VeryEasy = 10,
        Easy = 20,
        Medium = 45,
        Hard = 70,
        Critical = 90,
        Maximum = 100
    }
}
