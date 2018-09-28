using System;
using Github.Drawer.Abstractions;

namespace Github.Drawer.Logger
{
    class ConsoleLogger : ILogger
    {
        public void Info(string message)
        {
            Console.WriteLine($"[INFO]{message}");
        }

        public void Error(string message, Exception exception)
        {
            Console.WriteLine($"[Error] Message: {message}");
            Console.WriteLine($"[Error] Exception message: {exception.Message}");
            //Error(exception);
        }

        public void Error(Exception exception)
        {
            Console.WriteLine($"[Error]{exception.Message}");
            Console.WriteLine($"[StackTrace]{exception.StackTrace}");
        }
    }
}