using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensibleLoanCalculator.Lab
{
    class Program
    {
        private const string extensionsDirectory = @"..\..\..\Extensions\";
        private static FileSystemWatcher extensionsWatcher;
        private static LoanCalculatorContainer container;

        static void Main(string[] args)
        {
            Console.WriteLine("=== Application Started ====");

            extensionsWatcher = new FileSystemWatcher(extensionsDirectory);
            extensionsWatcher.Created += extensionsWatcher_Created;
            extensionsWatcher.Deleted += extensionsWatcher_Deleted;
            extensionsWatcher.EnableRaisingEvents = true;

            container = new LoanCalculatorContainer(extensionsDirectory);

            PrintPluginInfo();

            foreach (var loanCalculator in container.Extensions)
            {
                Console.WriteLine(loanCalculator.Value.GetInterest(10000, 12.0d, 3));
            }
            Console.ReadLine();
        }

        static void extensionsWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            extensionsDirectoryUpdated(sender, e);
        }

        static void extensionsWatcher_Created(object sender, FileSystemEventArgs e)
        {
            extensionsDirectoryUpdated(sender, e);
        }

        private static void extensionsDirectoryUpdated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("Directory Updated. Reloading plugins.......ln");
            container.LoadExtensions();
            PrintPluginInfo();
        }

        private static void PrintPluginInfo()
        {
            Console.WriteLine("\n{0} plugin(s) loaded..", container.Extensions.Count);
            Console.WriteLine("Displaying plugin info...\n");

            foreach (var loanCalculator in container.Extensions)
            {
                Console.WriteLine("==============================================");
                Console.WriteLine("Name: {0}", loanCalculator.Metadata.DisplayName);
                Console.WriteLine("Description: {0}", loanCalculator.Metadata.Description);
                Console.WriteLine("Version: {0}", loanCalculator.Metadata.Version);

                Console.WriteLine(loanCalculator.Value.GetInterest(10000, 12.0d, 3));
                
            }
        }
    }
}
