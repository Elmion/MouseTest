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
                var CurrentXMLCard = doc.DocumentElement.FirstChild;
                do
                {
                    SlotBuff sb = new SlotBuff();

                     sb.Name = CurrentXMLCard["Name"].InnerText;
                     sb.Description = CurrentXMLCard["Description"].InnerText;
                     sb.Event = CurrentXMLCard["Trigger"].InnerText;
                     sb.Method = typeof(Effect).GetMethod(CurrentXMLCard["MethodName"].InnerText);

                     ParameterInfo[] info = sb.Method.GetParameters();
                     var MethodParams = CurrentXMLCard["Param"].FirstChild;
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
                    CurrentXMLCard = CurrentXMLCard.NextSibling;
                    BuffList.Add(sb);
                } while (CurrentXMLCard != null);
            }
            public SlotBuff FindBuff(string NameBuff)
            {
               return BuffList.FirstOrDefault(x => x.Name == NameBuff);
            }
        }
    }


