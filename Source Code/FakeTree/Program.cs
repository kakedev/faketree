using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;
using System.Diagnostics;

namespace FakeTree
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLineFormatted("Press any key to start {0} and {1} diagnosis...", "NETWORK", "FILE", Color.MediumPurple, Color.AliceBlue);

            Console.ReadKey();

            var tree = new Process()
            {
                StartInfo =
                {
                    FileName = $"{Environment.GetFolderPath(Environment.SpecialFolder.Windows)}\\System32\\tree.com",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            tree.OutputDataReceived += (sender, eventArgs) => { Console.WriteLine(eventArgs.Data, Color.AliceBlue); };

            tree.Start();
            tree.BeginOutputReadLine();
            tree.WaitForExit();

            var styleSheet = new StyleSheet(Color.GreenYellow);
            styleSheet.AddStyle("║", Color.AliceBlue);
            styleSheet.AddStyle("╗", Color.AliceBlue);
            styleSheet.AddStyle("╝", Color.AliceBlue);
            styleSheet.AddStyle("╚", Color.AliceBlue);
            styleSheet.AddStyle("╔", Color.AliceBlue);
            styleSheet.AddStyle("═", Color.AliceBlue);

            Console.WriteLineStyled("╔═════════════════════════════╗", styleSheet);
            Console.WriteLineStyled("║ All Connections Are Safe!   ║", styleSheet);
            Console.WriteLineStyled("║ No Viruses Found!           ║", styleSheet);
            Console.WriteLineStyled("║ Firewall Is Up And Running! ║", styleSheet);
            Console.WriteLineStyled("╚═════════════════════════════╝", styleSheet);

            //Console.ReadKey();
        }
    }
}
