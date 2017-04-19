using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;

namespace Core.SlotBuffSystem
{
    class SpellsBase
    {
            public static readonly SpellsBase Instance = new SpellsBase();
             List<SlotBuff> BuffList;
            private SpellsBase()
            {
                  BuffList  = new List<SlotBuff>();
            }
        public void LoadBuff()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Assembly.GetAssembly(typeof(SpellsBase)).GetManifestResourceStream("Core.SlotBuffSystem.SpellList.xml"));
            var CurrentXML = doc.DocumentElement.FirstChild;
            do
            {
                    SlotBuff sb = new SlotBuff();

                    sb.Name = CurrentXML["Name"].InnerText;
                    sb.Description = CurrentXML["Description"].InnerText;
                    sb.CastTrigger = CurrentXML["CastTrigger"].InnerText;

                    var StagesXML = CurrentXML.SelectNodes("Stage");
                    for (int j = 0; j < StagesXML.Count; j++)
                    {


                        SlotSpellStage slotStage = new SlotSpellStage();
                        slotStage.RefParent = sb;
                        slotStage.Method = typeof(Effect).GetMethod(StagesXML[j]["MethodName"].InnerText);
                        slotStage.SlotTargets = StagesXML[j]["SlotTargetMap"].InnerText;
                        slotStage.Event = StagesXML[j]["Trigger"].InnerText;
                        slotStage.RemoveEvent = StagesXML[j]["RemoveTrigger"].InnerText;
                        slotStage.Timer = int.Parse(StagesXML[j]["RemoveTimer"].InnerText);
                        ParameterInfo[] info = slotStage.Method.GetParameters();
                        var MethodParams = StagesXML[j]["Param"].FirstChild;
                        for (int i = 0; i < info.Length; i++)
                        {
                            slotStage.TypeObj.Add(info[i].ParameterType);
                            if (info[i].ParameterType == typeof(int))
                            {
                                slotStage.Obj.Add(int.Parse(MethodParams.InnerText));
                            }
                            else
                            if (info[i].ParameterType == typeof(string))
                            {
                                slotStage.Obj.Add(MethodParams.InnerText);
                            }
                            else
                            {
                                slotStage.Obj.Add(MethodParams.InnerText);
                            }
                            MethodParams = MethodParams.NextSibling;
                        }
                        sb.Stages.Add(slotStage);
                    }
                    BuffList.Add(sb);
                    CurrentXML = CurrentXML.NextSibling;
                } while (CurrentXML != null);
        }
            public SlotBuff FindBuff(string NameBuff)
            {
               return BuffList.FirstOrDefault(x => x.Name == NameBuff);
            }
        }
    }


