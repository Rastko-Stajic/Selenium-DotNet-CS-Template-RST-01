using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Structura.GuiTests.Utilities
{
    public abstract class FileUtil
    {
        public static IList<string> ReadText(string filePath)
        {
            IList<string> lines = new List<string>();
            try
            {
                string line = "";
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(sr.ReadLine());
                    }
                }
            }
            catch (Exception e) { }

            return lines;
        }

        public static void WriteText(IList<string> lines, string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (string line in lines)
                    {
                        sw.WriteLine(line);
                    }
                    sw.Close();
                }
            }
            catch (Exception e) { }
        }
    }
}
