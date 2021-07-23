using System;

namespace DotNetDependencyInjection.examples._01
{
    public class ConsoleMessageWriter: IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine($"MessageWriter.Write(message: \"{message}\")");
        }
    }
}