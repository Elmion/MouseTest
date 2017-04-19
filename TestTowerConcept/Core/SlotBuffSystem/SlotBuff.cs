using System.Reflection;
using System;
using System.Collections.Generic;
namespace Core
{
    internal class SlotBuff
    {
        public string Name        { get; set; }
        public string Description { get; set; }
        public string CastTrigger { get; set; }
        public List<SlotSpellStage> Stages { get; set; }
        public SlotBuff()
        {
            Stages = new List<SlotSpellStage>();
        }

    }
    internal class SlotSpellStage
    {
        public SlotBuff RefParent { get; set; }
        public string SlotTargets { get; set; }
        public string Event { get; set; }
        public string RemoveEvent { get; set; }
        public int Timer { get; set; }
        public List<string> MobsFilter { get; set; }
        public MethodInfo Method { get; set; }
        public List<Type> TypeObj { get; set; }
        public List<object> Obj { get; set; }

        public SlotSpellStage()
        {
            MobsFilter = new List<string>();
            TypeObj = new List<Type>();
            Obj = new List<object>();
        }
    }


}