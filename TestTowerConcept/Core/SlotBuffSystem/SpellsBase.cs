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
                     sb.Event = CurrentXML["Trigger"].InnerText;
                     sb.Method = typeof(Effect).GetMethod(CurrentXML["MethodName"].InnerText);
                     var MethodTargets = CurrentXML["Targets"].FirstChild;
                     do
                        {
                            sb.Targets.Add(typeof(Targets).GetMethod(MethodTargets.InnerText));
                            MethodTargets = MethodTargets.NextSibling;
                        } while (MethodTargets != null);

                     ParameterInfo[] info = sb.Method.GetParameters();
                     var MethodParams = CurrentXML["Param"].FirstChild;
                     for (int i = 0; i < info.Length; i++)
                        {
                             sb.TypeObj.Add(info[i].ParameterType);
                                if (info[i].ParameterType == typeof(int))
                                {
                                    sb.Obj.Add(int.Parse(MethodParams.InnerText));
                                } else
                                if(info[i].ParameterType == typeof(string))
                                {
                                    sb.Obj.Add(MethodParams.InnerText);
                                } else
                                {
                                    sb.Obj.Add(MethodParams.InnerText);
                                }
                             MethodParams = MethodParams.NextSibling;
                        }
                    CurrentXML = CurrentXML.NextSibling;
                    BuffList.Add(sb);
                } while (CurrentXML != null);
            }
            public SlotBuff FindBuff(string NameBuff)
            {
               return BuffList.FirstOrDefault(x => x.Name == NameBuff);
            }
        }
    }


