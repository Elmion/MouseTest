using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;

namespace CommonElement
{
    public class CardsBase
    {
        public static readonly CardsBase Instance = new CardsBase();
        private List<Card> CardsBook;
        private CardsBase()
        {
            CardsBook = new List<Card>();
        }
        public void  LoadCards()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Assembly.GetAssembly(typeof(CardsBase)).GetManifestResourceStream("CommonElement.Cards.xml"));
            var CurrentXMLCard = doc.DocumentElement.FirstChild;
            PropertyInfo[] info = typeof(Card).GetProperties();
            do
            {
                Card c = new Card();
                for (int i = 0; i < info.Length; i++)
                {
                    if(info[i].PropertyType == typeof(int))
                    {
                        info[i].SetValue(c, int.Parse(CurrentXMLCard[info[i].Name].InnerText));
                    }
                    if(info[i].PropertyType == typeof(string))
                    {
                        info[i].SetValue(c, CurrentXMLCard[info[i].Name].InnerText);
                    }
                }
                CardsBook.Add(c);
                CurrentXMLCard = CurrentXMLCard.NextSibling;
            } while (CurrentXMLCard != null);
        }
        public Card GetClone(string CardName)
        {
            Card cardOut = new Card();
            Card Origin = CardsBook.First<Card>(x => x.Name == CardName);
            if (Origin == null) return null; //ненашли
            //нашли .. клонируем.
            PropertyInfo[] info = typeof(Card).GetProperties();
            for (int i = 0; i < info.Length; i++)
            {
                info[i].SetValue(cardOut, info[i].GetValue(Origin));
            }
            return cardOut;
        }
    }
}
