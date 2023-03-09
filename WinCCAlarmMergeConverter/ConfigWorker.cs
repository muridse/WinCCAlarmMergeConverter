using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinCCAlarmMergeConverter
{

    public class ConfigWorker
    {
        public readonly Dictionary<int, int> ClassReplaseMap= new Dictionary<int, int>();
        public readonly Dictionary<int, int> TypeReplaseMap = new Dictionary<int, int>();

        private string ClassPath = null;
        private string TypePath = null;

        public ConfigWorker(string classConfigPath, string typeConfigPath) 
        {
            ClassPath= classConfigPath;
            TypePath= typeConfigPath;
            ClassReplaseMap = MakeClassReplaceMap();
            TypeReplaseMap = MakeTypeReplaceMap();
        }

        private Dictionary<int,int> MakeClassReplaceMap() 
        {
            String line;
            Dictionary<int, int> classMap= new Dictionary<int, int>();
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                
                if (!System.IO.File.Exists(ClassPath)) 
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Add .conf file with classes");
                    Console.BackgroundColor= ConsoleColor.Black;
                } 
                StreamReader sr = new StreamReader(ClassPath);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    var arrLine = line.Split(new char[] { ' ' });
                    //write the line to console window
                    int originClass;
                    int replaceClass;
                    if (Int32.TryParse(arrLine[0], out originClass) && Int32.TryParse(arrLine[2], out replaceClass))
                    {
                        classMap.Add(originClass, replaceClass);
                    }

                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            
            return classMap;
        }
        private Dictionary<int, int> MakeTypeReplaceMap()
        {
            String line;
            Dictionary<int, int> typeMap = new Dictionary<int, int>();
            try
            {
                //Pass the file path and file name to the StreamReader constructor

                if (!System.IO.File.Exists(ClassPath))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Add .conf file with types");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                StreamReader sr = new StreamReader(TypePath);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    var arrLine = line.Split(new char[] { ' ' });
                    //write the line to console window
                    int originType;
                    int replaceType;
                    if (Int32.TryParse(arrLine[0], out originType) && Int32.TryParse(arrLine[2], out replaceType))
                    {
                        typeMap.Add(originType, replaceType);
                    }

                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return typeMap;
        }
    }
}
