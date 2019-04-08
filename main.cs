using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Management;
using System.Management.Instrumentation;
using System.IO;
using System.Threading;
using System.Security.Policy;

class MainClass
{
    public static bool UserTrue = false;
    public static void Main()
    {
        ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
        dsk.Get();
        string id = dsk["VolumeSerialNumber"].ToString();


        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
      


       

        string file = System.IO.File.ReadAllText(@"Data.pref");

        System.Console.WriteLine(file);
        // this works for now, keeping it
        string input = Console.ReadLine();

        if (input == "/admin clear") {

            string aClear = "";
            System.IO.File.WriteAllText(@"Data.pref", aClear);

        }
        string username = id;


        string newText = file + '\n' + username + ">> " + input;

        System.IO.File.WriteAllText(@"Data.pref", newText);
        Process neu = new Process();
        neu.StartInfo.FileName = @"Chtrm.exe";
        neu.Start();
        Environment.Exit(0);

    }

}
