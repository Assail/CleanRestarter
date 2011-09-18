using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace EveRestarter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() != 1)
                return;
               
	

            Process[] processlist = Process.GetProcesses().Where(p => p.ProcessName == "ExeFile").ToArray<Process>();


            while (processlist.Count() > 0)
            {
                foreach(Process theprocess in processlist){
                    Console.WriteLine("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id);
                    theprocess.Kill();

                }
                Thread.Sleep(5000);
                processlist = Process.GetProcesses().Where(p => p.ProcessName == "ExeFile").ToArray<Process>();
            }

            string filename64 = @"C:\Program Files (x86)\Innerspace\InnerSpace.exe";
            string filename32 = @"C:\Program Files\Innerspace\InnerSpace.exe";

            Process pr = new Process();

            FileInfo finfo64 = new FileInfo(filename64);
            
            if (finfo64.Exists)
            {
                pr.StartInfo.FileName = filename64;
            }
            else
            {
                pr.StartInfo.FileName = filename32;
            }

            pr.StartInfo.Arguments = String.Format("run isboxer -launch \"{0}\"", args[0]);
            pr.Start();
            Thread.Sleep(5000);


        }
    }
}
