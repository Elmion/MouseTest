using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health
{
    public class BodyHealth
    {
        List<IBodySystem> Systems;

        public BodyHealth()
        {
            Systems = new List<IBodySystem>();
        }
        public void Update()
        {

        }
    }
}
