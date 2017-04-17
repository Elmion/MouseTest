using CommonElement;
using System.Reflection;
namespace Core
{
    internal class Effect
    {
        public int EffectTime;
        public Card ChangeParamProcent(Card card, string ParamCard,int valueChange)
        {
            PropertyInfo info = typeof(Card).GetProperty(ParamCard);
            if (info != null &&  info.PropertyType == typeof(int))
            {
                int currentValue = (int)info.GetValue(card);
                typeof(Card).GetProperty(ParamCard).SetValue(card, (int)(currentValue * (1f + valueChange / 100.0f)));
            }
            return card;
        }
        public Card ChangeParamAbsolute(Card card, string ParamCard, int valueChange)
        {
            PropertyInfo info = typeof(Card).GetProperty(ParamCard);
            if (info != null && info.PropertyType == typeof(int))
            {
                int currentValue = (int)info.GetValue(card);
                typeof(Card).GetProperty(ParamCard).SetValue(card, currentValue + valueChange );
            }
            return card;
        }
    }
}