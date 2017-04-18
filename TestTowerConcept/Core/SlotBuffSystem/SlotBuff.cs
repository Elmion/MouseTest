using System.Reflection;
using System;
using System.Collections.Generic;
namespace Core
{
    internal class SlotBuff
    {
        public string Name        { get; set; }
        public string Description { get; set; }
        public string Event       { get; set; }

        public MethodInfo Method { get; set; }
        public List<Type> TypeObj     { get; set; }
        public List<object> Obj { get; set; }

        public SlotBuff()
        {
            TypeObj = new List<Type>();
            Obj = new List<object>();
        }
    }
}