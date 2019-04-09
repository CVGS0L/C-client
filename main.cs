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
        // this gets the HWID of the hard drive to use as a pseudo user name.
        ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
        dsk.Get();
        string id = dsk["VolumeSerialNumber"].ToString();

        //set the console colors
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
      


       
        // reads a file and saves it as a string
        string file = System.IO.File.ReadAllText(@"<file (and drive) to open>");
         // writes file to console
        System.Console.WriteLine(file);
        // gets user input
        string input = Console.ReadLine();
        //checks for commands (does not work)
        if (input == "/admin clear") {

            string aClear = "";
            System.IO.File.WriteAllText(@"Data.pref", aClear);

        }
        // sets HWID we got earlier as a username
        string username = id;

        // adds new stuff to the old string.
        string newText = file + '\n' + username + ">> " + input;
        // writes the new string to file that was opened earlier
        System.IO.File.WriteAllText(@"<file (and drive) to open>", newText);
        //closes the program and opens itself agian (to close the file so others can write to it, as well as acting as a refresh)
        Process neu = new Process();
        neu.StartInfo.FileName = @"<whatever you save this application as>";
        neu.Start();
        Environment.Exit(0);

    }

}
