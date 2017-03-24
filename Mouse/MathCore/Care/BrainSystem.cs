using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore.Care
{
    class BrainSystem
    {
        const float OXI_FULL_USAGE_COST = 1;
        public float SleepLevel { get; set; }

        float _usage = 0;
        List<IMentalWork> WorkInProgress;
        Intensive UsageLevel
        {
            get
            {
                if (_usage >= 0 && _usage < 15)    return Intensive.very_easy;
                if (_usage >= 15 && _usage < 30)   return Intensive.easy;
                if (_usage >= 30 && _usage < 55)   return Intensive.medium;
                if (_usage >= 55 && _usage < 75)   return Intensive.hard;
                if (_usage >= 75 && _usage < 85)   return Intensive.very_hard;
                if (_usage >= 85 && _usage < 99)   return Intensive.critical;
                if (_usage >= 99 && _usage <= 100) return Intensive.fatal;
                return Intensive.very_easy;
            }
        } 
        public BrainSystem()
        {
            WorkInProgress = new List<IMentalWork>();
        }
        public bool Update(ref BloodStream blood)
        {
            SystemResurceConsume(ref blood);
            return CheckStatus();
        }
        public bool WorkBegin(IMentalWork WorkLoad)
        {
            if (WorkInProgress.Count < 5)
            {
                WorkInProgress.Add(WorkLoad);
                usageRecalc();
                return true;
            }
            return false;
        }
        public void WorkEnd(IMentalWork WorkLoad)
        {
            WorkInProgress.Remove(WorkLoad);
            usageRecalc();
        }
        private void usageRecalc()
        {
            _usage = 0;
            for (int i = 0; i < WorkInProgress.Count; i++)
            {
                _usage += WorkInProgress[i].MeasureWorkHard;
            }
        }
        private bool CheckStatus()
        {
            throw new NotImplementedException();
        }
        private void SystemResurceConsume(ref BloodStream blood)
        {
            blood.Upload(OxiLevel -= _usage / 100 * OXI_FULL_USAGE_COST;
        }

        neurosystem,
                vitaminB
                Magnii
                glucose
        Brain
                oxige
                glucozeLevel
    }
}
