using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinCCAlarmMergeConverter
{
    internal class AlarmWriter
    {
        private string UpdatedAlarmFilePath;
        private readonly Encoding CurrentEncoding;
        public AlarmWriter(string filePath, List<string> updatedAlarms, Encoding currentEncoding) 
        {
            UpdatedAlarmFilePath= filePath;
            File.Delete(UpdatedAlarmFilePath);
            CurrentEncoding= currentEncoding;
            WriteFile(updatedAlarms);
        }
        private void WriteFile(List<string> updatedAlarms) 
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(UpdatedAlarmFilePath, true, CurrentEncoding);
                foreach (var line in updatedAlarms)
                {
                    //Write a line of text
                    sw.WriteLine(line);
                }
                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
