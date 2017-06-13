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
            HistoryField = data.GameField.ToString();
            if (PreInstallField == string.Empty)
            {
                data.GameField.Clear();
                for (int i = 0; i < 108; i++)
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
            data.History.Add(this);
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
            if(HistoryField != "") data.RefreshCuplesData(); //откатываемся до пустого поля но пары не формируем
            return true;
        }

    }
}
