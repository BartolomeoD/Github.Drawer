using System;

namespace Github.Drawer.Abstractions
{
    interface ILogger
    {
        void Info(string message);

        void Error(string message, Exception exception);

        void Error(Exception exception);
    }
}