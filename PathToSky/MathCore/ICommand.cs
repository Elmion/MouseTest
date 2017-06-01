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
        void Undo();
    }
}
