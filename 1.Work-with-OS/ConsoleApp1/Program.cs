
using System;
using System.Diagnostics;
using System;
using System.Diagnostics;


namespace Session1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter the number between 1 to 4 (Enter 0 to exit):");
                int state = int.Parse(Console.ReadLine());
                Process[] plist = Process.GetProcesses();

                switch (state)
                {
                    case 1:
                        Console.WriteLine("Please enter the process name that you want to start:");
                        string name = Console.ReadLine();
                        Process.Start(name);
                        break;
                    case 2:
                        Console.WriteLine("The process list:");
                        foreach (Process p in plist)
                            Console.WriteLine(p.Id + "\t" + p.ProcessName);
                        break;
                    case 3:
                        Console.WriteLine("Please enter the name of the process that you want to kill:");
                        string name0 = Console.ReadLine();
                        foreach (Process p in plist)
                        {
                            if (p.ProcessName == name0)
                                p.Kill();
                        }
                        break;
                    case 4:
                        Console.WriteLine("Please enter the name of the process:");
                        string child = Console.ReadLine();
                        foreach (Process p in plist)
                        {
                            if (p.ProcessName == child)
                                Console.WriteLine("The parent process is: " + p.Handle);
                        }
                        break;
                    case 0:
                        Console.WriteLine("Exiting the program...");
                        return; // Exit the program
                    default:
                        Console.WriteLine("Please enter a valid number between 1 to 4 or 0 to exit.");
                        break;
                }
            }
        }
    }
}
