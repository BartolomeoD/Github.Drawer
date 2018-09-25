using System.Collections.Generic;
using Github.Drawer.Points;
using Github.Drawer.Schema;

namespace Github.Drawer.Abstractions
{
    public interface IPointPositionCalculator
    {
        IEnumerable<PointPosition> Handle(SchemaEntity schema);
    }
}
