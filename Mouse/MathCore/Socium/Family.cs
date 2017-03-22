using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore.Socium
{
    internal class Family
    {
        Mouse BetterHalf;
        List<Children> childrens;
        public void Merry(Mouse mouse)
        {

        }
        void BirthChildren(int count)
        {
            for (int i = 0; i < count; i++)
            {
                childrens.Add(new Children());
            }
        }
    }
    public enum FamilyRole
    {
        Father,
        Mother,
        GrandFather,
        GrandMother,
        Son,
        Dotgher
    }
}
