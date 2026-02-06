using System;
using System.Runtime.InteropServices;

namespace Quesion1 {
    internal class Program {
        static void Main(){
            string FWVersion = RuntimeInformation.FrameworkDescription;
            string OS = RuntimeInformation.OSDescription;
            string OSArch = RuntimeInformation.OSArchitecture.ToString();
            string CPUArch = RuntimeInformation.ProcessArchitecture.ToString();

            System.Console.WriteLine($"Runtime Version: {FWVersion}");

            if (FWVersion.Contains(".NET Framework")) System.Console.WriteLine("Legacy Runtime");
            else System.Console.WriteLine("Modern .NET Runtime");

            System.Console.WriteLine($"Operatin System: {OS}");
            System.Console.WriteLine($"Operating System Architecture: {OSArch}");
            System.Console.WriteLine($"CPU Architecture: {CPUArch}");

        }
    }
}