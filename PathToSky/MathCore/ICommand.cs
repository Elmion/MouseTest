using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore
{
  public interface ICommand
    {
        object Execute(CoreData data); 
        object Undo(CoreData data);
        object Redo(CoreData data);
    }
}
