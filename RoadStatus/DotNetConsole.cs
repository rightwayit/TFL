using System;
using System.IO;
using Tfl.Api.Presentation.Entities;

namespace RoadStatus
{
    public class DotNetConsole : IConsole
    {
        public DotNetConsole()
        {
            ResetConsoleOut();
        }

        public void ResetConsoleOut()
        {
            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            System.Console.SetOut(standardOutput);
        }
        
        
        public void Write(RoadCorridor roadCorridor)
        {
            WriteLine("The status of the A2 is as follows");
            WriteLine($"Road Status is {roadCorridor.statusSeverity}.");
            WriteLine($"Road Status Description is {roadCorridor.statusSeverityDescription}.");
        }

        public void WriteNotValid(string roadId)
        {
            WriteLine($"{roadId} is not a valid road.");
        }

        public void WriteLine(string text = "")
        {
            Console.WriteLine(text);
            Console.Out.Flush();
        }

        public virtual void Pause()
        {
            Console.ReadLine();
        }
    }
}
