using System;

namespace Github.Drawer.Abstractions
{
    public interface ILogger
    {
        void Info(string message);

        void Error(string message, Exception exception);

        void Error(Exception exception);
    }
}