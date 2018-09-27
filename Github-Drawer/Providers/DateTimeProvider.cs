using System;
using Github.Drawer.Abstractions;

namespace Github.Drawer.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetToday()
        {
            return DateTime.Today;
        }

        public DateTime GetNow()
        {
            return DateTime.Now;
        }
    }
}
