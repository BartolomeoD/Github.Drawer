using System;

namespace Github.Drawer.Abstractions
{
    public interface IDateTimeProvider
    {
        DateTime GetToday();
    }
}
