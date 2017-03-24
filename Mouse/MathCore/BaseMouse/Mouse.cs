using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore
{
    public class Mouse
    {
        const float SPEED_DEC_HEART_TIK = 1.5f;
        const float NORMAL_HEART_TIK = 60f;
        const float MAX_HEART_TIK = 170f;
        const float MAX_HANGRY = 100f;
        float LifeTime = 10800; //секунды
        public float Hangry  {get;set;}
        float MouseDNAPower;
        float MousePowerTrainingArgument = 1.0f;
        float EquvipmentArgument = 1.0f;
        float HeartTraningArgument = 1.0f;
        float _heartTik = 60.0f;
        float Stress;

        bool Male = true; // по умолчанию мужик.
        Inventory _inventory;

        /// <summary> Времянки
        public float PowerOUTBUFFERED;
        /// </summary>

        int StatusRun = 0;
        public int HeartTik
        {
            get
            {
                return (int)Math.Floor(_heartTik);
            }
        }
        public Mouse(float DNAPower)
        {
            MouseDNAPower = DNAPower;
            Hangry = 100;
            _inventory = new Inventory();
        }
        public float PhisicPower()
        {
            _heartTik += HeartTraningArgument* (MAX_HEART_TIK - _heartTik) / MAX_HEART_TIK *20;
            LifeTime -= 0.2f;

            //--------ВЫРЕЗАТЬ НАФИГ
            PowerOUTBUFFERED = MouseDNAPower * MousePowerTrainingArgument * EquvipmentArgument;
            //------------------
            return MouseDNAPower * MousePowerTrainingArgument * EquvipmentArgument;
        }
        public float MentalPower()
        {

        }
        public void Update()
        {
            _heartTik -= HeartTraningArgument * SPEED_DEC_HEART_TIK;
            if (_heartTik < NORMAL_HEART_TIK) _heartTik = NORMAL_HEART_TIK;
            Hangry -= 0.01f + 0.2f * (1- (MAX_HEART_TIK - _heartTik) / (MAX_HEART_TIK-NORMAL_HEART_TIK));
        }
        public void MouseEat(IFood food)
        {
            Hangry += food.GetColories;
            if (Hangry > MAX_HANGRY)
                Hangry = MAX_HANGRY;
        }
        public void Equip(IEquipment e)
        {
            _inventory.PutInSlot(e);
            EquvipmentArgument = _inventory.CalcEquipmentBonus();
        }
    }
}
