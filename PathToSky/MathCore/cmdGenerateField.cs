using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore
{
   public class cmdGenerateField : ICommand
    {
        private string HistoryField = "";
        private string PreInstallField = string.Empty;
        public cmdGenerateField()
        {    
        }
        public cmdGenerateField(string field)
        {
            PreInstallField = field;
        }
        public object Execute(CoreData data)
        {
            if (PreInstallField == string.Empty)
            {
                data.GameField.Clear();
                for (int i = 0; i < 27; i++)
                {
                    data.GameField.Append(Core.rnd.Next(0, 10));
                }
            }
            else
            {
                data.GameField.Clear();
                data.GameField.Append(PreInstallField);
            }
            data.RefreshCuplesData();
            HistoryField = data.GameField.ToString();
            return true;
        }

        public object Redo(CoreData data)
        {
            throw new NotImplementedException();
        }
        public object Undo(CoreData data)
        {
            data.GameField.Clear();
            data.GameField.Append(HistoryField);
            data.RefreshCuplesData();
            return true;
        }

    }
}
