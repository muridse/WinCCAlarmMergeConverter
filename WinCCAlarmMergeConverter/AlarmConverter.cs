using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinCCAlarmMergeConverter
{
    internal class AlarmConverter
    {
        private readonly string AlarmFilePath = null;
        private List<string> AlarmList = new List<string>();
        private ConfigWorker ConfigWorker;
        public Encoding CurrentEncoding;

        public AlarmConverter(string alarmFilePath, ConfigWorker configWorker) 
        {
            AlarmFilePath = alarmFilePath;
            ConfigWorker = configWorker;
            ParseFile();
            UpdateAlarms();
        }
        private void ParseFile() 
        {
            AlarmList.Clear();
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                if (!System.IO.File.Exists(AlarmFilePath))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Add alarm export file to AlarmFile directory");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                StreamReader sr = new StreamReader(AlarmFilePath);
                CurrentEncoding = IncodingDetector.GetEncoding(AlarmFilePath);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    AlarmList.Add(line);
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
        }
        private void UpdateAlarms() 
        {
            for (int i = 1; i < AlarmList.Count; i++)
            {
                var splittedArr = AlarmList[i].Split(',', 8);


                int newClass;
                int newType;
                if (ConfigWorker.ClassReplaseMap.TryGetValue(Int32.Parse(splittedArr[2]), out newClass)) 
                {//Class update
                    splittedArr[2] = newClass.ToString();
                }
                if (ConfigWorker.TypeReplaseMap.TryGetValue(Int32.Parse(splittedArr[3]), out newType)) 
                {//Type update
                    splittedArr[3] = newType.ToString();
                }
                AlarmList[i] = string.Join(",", splittedArr);
                
            }
        }
        public List<string> GetUpdatedList() 
        {
            return AlarmList;
        }
    }
}
