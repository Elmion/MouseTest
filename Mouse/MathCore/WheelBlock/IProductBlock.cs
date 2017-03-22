using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore
{
    public interface IProductBlock
    {
       float NeedPower {get;}
       bool EnablePower { get; set; }
    }
}
