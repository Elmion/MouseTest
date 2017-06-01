using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore
{
   public class cmdGenerateField : ICommand
    {
        private string PreInstallField = string.Empty;
        public cmdGenerateField()
        {    
        }
        public cmdGenerateField(string field)
        {
            PreInstallField = field;
        }
        public object Execute(CoreData core)
        {
            if (PreInstallField == string.Empty)
            {
                core.GameField.Clear();
                for (int i = 0; i < 27; i++)
                {
                    core.GameField.Append(Core.rnd.Next(0, 10));
                }
            }
            else
            {
                core.GameField.Clear();
                core.GameField.Append(PreInstallField);
            }
            core.RefreshCuplesData();
            PreInstallField = string.Empty;
            return true;
        }
        public void Undo()
        {

        }
    }
}
