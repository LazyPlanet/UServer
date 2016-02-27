using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Share_Common;

namespace GameServer.Template
{
    class TemplateManager
    {
        /*
        * Member
        * */
        public static String m_ResourcePath = "F:\\Project\\Cpp\\GameServer\\GameServer\\Items";
        private static TemplateManager m_Instance = null;
        private static Dictionary<String, List<Object>> m_Tempaltes = new Dictionary<String, List<Object>>();
        /*
        * Constructor
        * */
        public TemplateManager()
        {

        }

        /*
        * Load template
        * */
        public static bool Load()
        {
            try
            {
                System.Object instance = null;

                DirectoryInfo dirs = new DirectoryInfo(m_ResourcePath);
                foreach (DirectoryInfo dir in dirs.GetDirectories())
                {
                    if (dir.Attributes == FileAttributes.Hidden) continue;
                    DirectoryInfo files = new DirectoryInfo(dir.FullName);
                    if (!files.Exists) continue;

                    String itemType = dir.Name.ToString();
                    System.Type typeName = System.Type.GetType("Pb." + itemType);
                    if (typeName != null) instance = System.Activator.CreateInstance(typeName);
                    
                    List<Object> values = new List<Object>();
                    foreach (FileInfo file in files.GetFiles())
                    {
                        using (var des = System.IO.File.OpenRead(file.FullName))
                        {
                            instance = ProtoBuf.Serializer.NonGeneric.Deserialize(typeName, des);
                            values.Add(instance);
                        }
                    }
                    m_Tempaltes.Add(itemType, values);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Load template error:" + ex.Message);
                return false;
            }

            return true;
        }
        /*
        * Load special templates
        * */
        public List<Object> GetSpecialTemplates(String name)
        {
            if (m_Tempaltes.ContainsKey(name))
            {
                List<Object> list = m_Tempaltes[name];
                return list;
            }
            return null;
        }
        /*
        * Load special template : Medichine
        * */
        public List<Object> GetMedichines()
        {
            return this.GetSpecialTemplates("Medichine");
        }
        /*
        * Get Medichine from tid
        * */
        public Item_Medichine GetMedichine(int tid)
        {
            foreach (Item_Medichine medichine in GetMedichines())
            {
				if (medichine.tid == tid) return medichine;
            }
            return null;
        }
        // End of class TemplateManager
    }
    // End of namespace GameServer
}
