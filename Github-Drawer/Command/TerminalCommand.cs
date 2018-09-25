using System.Collections.Generic;

namespace Github.Drawer.Command
{
    public class Command
    {
        public string ServiceName { get; }
        public Dictionary<string, string> Pars { get; }

        public Command(string serviceName, Dictionary<string, string> pars)
        {
            ServiceName = serviceName;
            Pars = pars;
        }
    }
}
