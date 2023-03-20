using System;
using System.IO;
using System.Linq;
using System.Text;

namespace WinCCAlarmMergeConverter
{
    internal static class Program
    {
        readonly static string ConfigClass = "..\\config\\convertClass.conf";
        readonly static string ConfigType = "..\\config\\convertType.conf";
        readonly static string OriginalAlarmFile = "..\\AlarmFile\\template.txt";
        readonly static string ModdedAlarmFile = "..\\AlarmFile\\templateModded.txt";
        private static void Main(string[] args)
        {
            Console.WriteLine("*If .conf file notation:");
            Console.WriteLine("convertClass.conf : Old Class Name -> New Class Name");
            Console.WriteLine("convertType.conf : Old Type Name -> New Type Name\n");
            MakePaths();

            Console.WriteLine("WinCC Alarms Merge Converter started, creating replacement map...");
            var configWorker = new ConfigWorker(ConfigClass, ConfigType);
            Console.WriteLine("Done.\n");


            Console.WriteLine("Scaning and updating alarms...");
            var alarmConverter = new AlarmConverter(OriginalAlarmFile, configWorker);
            Console.WriteLine("Done.\n");


            Console.WriteLine("Creating new alarms file...");
            var alarmWriter = new AlarmWriter(ModdedAlarmFile, alarmConverter.GetUpdatedList(), alarmConverter.CurrentEncoding);
            
            Console.WriteLine("Done.\n");

            Console.ReadLine();
        }
        private static void MakePaths() 
        {
            if (!System.IO.File.Exists("..\\config")) 
            {
                System.IO.Directory.CreateDirectory("..\\config");
            }
            if (!System.IO.File.Exists("..\\AlarmFile"))
            {
                System.IO.Directory.CreateDirectory("..\\AlarmFile");
            }
        }
    }
}
