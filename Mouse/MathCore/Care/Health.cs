using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore.Care
{

    class Health
    {
        public float Age;
        public float Hangry;
        public float Sleep;

        //баланс тренерованости
        public float MuscleTonus;
        public float MuscleLevel;
        public float FatLevel;

        public float PhisicLevel;

        //На общий имуннитет влияют голод,возраст и пр.
        public float ImmunitetResurce { get; set; }
        public float BodyTemp { get; set; }
        public float Intaxication { get; set; }

        List<IBodyPart> BodyParts;
        public Health()
        {
            BodyParts = new List<IBodyPart>();
             
        } 
        void TakePhisicWork(Intensive worktype)
        {

        }
        void TakeMentalWork(Intensive worktype)
        {

        }
        void TakeTherapy(Therapy p)
        {

        }
        void TakeStress(Intensive i)
        {
            BodyParts.Find(x => x is Brain).GetHarm(Disease.MentalHarm, i);
        }

    }
    public enum Intensive
    {
        very_easy,
        easy,
        medium,
        hard,
        very_hard,
        critical,
        fatal
    }
    public enum StatusPart
    {
        Ok,
        Damaged,
        Destroy
    }
    public interface IBodyPart
    {
        bool GetHarm(Disease typeHarm, Intensive e);
        bool GetCare(Therapy t);
        List<string> GetHealthJornal();
        StatusPart Status { get; set; }
    }
      public enum Disease
    {
        Virus,
        Harm,
        Functional,
        MentalHarm
    }

}
