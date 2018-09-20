using System.IO;
using System.Text;
using Github.Drawer.Abstractions;

namespace Github.Drawer.Schema
{
    public class SchemaReader : ISchemaReader
    {
        private readonly ILogger _logger;

        SchemaReader(ILogger logger)
        {
            _logger = logger;
        }

        public SchemaEntity Read(Stream stream)
        {
            var buffer = new byte[stream.Length];
            var result = stream.Read(buffer, 0, buffer.Length);
            _logger.Info($"Result: {result}");
            var rows = Encoding.UTF8.GetString(buffer, 0, buffer.Length).Split('\n');
            if (rows.Length != 7)
                throw new SchemaException("Rows count should be 7");
            var schema = new SchemaEntity(rows.Length);
            for (var i = 0; i < rows.Length; i++)
            {
                if (rows[i].Length > 52)
                    throw new SchemaException("Rows length should be less than 53");

                for (var k = 0; k < rows[i].Length; k++)
                {
                    schema.Points[i, k] = (PointType) rows[i][k];
                }
            }

            return schema;
        }
    }
}