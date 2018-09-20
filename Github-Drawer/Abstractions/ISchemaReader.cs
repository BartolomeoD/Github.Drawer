using System.IO;
using Github.Drawer.Schema;

namespace Github.Drawer.Abstractions
{
    public interface ISchemaReader
    {
        SchemaEntity Read(Stream stream);
    }
}
