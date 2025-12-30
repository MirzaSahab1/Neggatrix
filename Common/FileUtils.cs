using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Common
{
    public static class FileUtils
    {
        public static string GetPath(string fileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Data\", fileName);
            return Path.GetFullPath(path);
        }
        public static string GetField(string fileName, int index)
        {
            string path = GetPath(fileName);
            if (!File.Exists(path))
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine("1,1,1,0,0");
                }
            }
            using (StreamReader reader = new StreamReader(path))
            {
                string? data = reader.ReadLine();
                if (data != null)
                {
                    string[] fields = data.Split(',');
                    if (index - 1 < fields.Length) return fields[index - 1];
                }
                return "";
            }
        }

        public static void SaveField(string fileName, int index, string value)
        {
            string path = GetPath(fileName);
            string? initialData;
            if (!File.Exists(path))
            {
                initialData = "1,1,1,0,0";
            }
            else
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    initialData = reader.ReadLine();
                }
                if (initialData != null)
                {
                    string[] fields = initialData.Split(",");
                    if (index - 1 < fields.Length) fields[index - 1] = value;
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        for (int i = 0; i < fields.Length; i++)
                        {
                            writer.Write(fields[i]);
                            if (i < fields.Length - 1) writer.Write(",");
                        }
                    }
                }
            }
        }
    }
}
