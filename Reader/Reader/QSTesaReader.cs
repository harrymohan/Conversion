using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace QSTesa
{
   public class QSTesaReader
    {
        static System.Collections.Hashtable ht = new System.Collections.Hashtable();



        public static string ReadPrintProperties(string keyName)
        {
            if (ht.ContainsKey(keyName))
            {
                return (string)ht[keyName];
            }
            if (INIfilePath == "")
            {
                INIfilePath = @GetINIPath();
            }
            string ret = string.Empty;
            try
            {
                QSecureIniFile iniFile = new QSecureIniFile(INIfilePath);
                ret = iniFile.IniReadValue("TesaProperties", keyName);
            }
            catch (Exception err)
            {
                //MessageBox.Show("ReadPrintProperties:" + err.Message);

            }
            ht.Add(keyName, ret);

            return ret;
        }


        public static string GetINIPath()
        {

            string path = GetCurrentDirectory();

            return path = path + "\\QSTesa.INI";

        }
       private static  string GetCurrentDirectory()
        {
            string path = Path.GetDirectoryName(
                  Assembly.GetAssembly(typeof(QSTesaReader)).CodeBase);
            path = path.Replace("file:\\", "");
            return path;
        }
        static string ret = string.Empty;
        public static string INIfilePath = "";

    }
}
