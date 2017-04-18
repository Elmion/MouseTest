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
        public string SlotTargets { get; set; }
        public List<string> MobsFilter { get; set; }
        public MethodInfo Method  { get; set; }
        public List<Type> TypeObj { get; set; }
        public List<object> Obj { get; set; }

        public SlotBuff()
        {
            MobsFilter = new List<string>();
            TypeObj = new List<Type>();
            Obj = new List<object>();
        }
    }
}