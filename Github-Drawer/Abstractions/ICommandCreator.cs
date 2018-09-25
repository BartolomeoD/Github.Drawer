using System;
using System.Collections.Generic;
using System.Text;
using Github.Drawer.Command;
using Github.Drawer.Points;

namespace Github.Drawer.Abstractions
{
    public interface ICommandCreator
    {
        IEnumerable<TerminalCommand> Create(IEnumerable<PointPosition> points);
    }
}
