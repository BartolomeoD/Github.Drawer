using System.IO;
using System.Linq;
using System.Text;
using Github.Drawer.Abstractions;
using static System.Char;

namespace Github.Drawer.Schema
{
    public class SchemaReader : ISchemaReader
    {
        private readonly ILogger _logger;

        public SchemaReader(ILogger logger)
        {
            _logger = logger;
        }

        public SchemaEntity Read(Stream stream)
        {
            var buffer = new byte[stream.Length];
            var result = stream.Read(buffer, 0, buffer.Length);
            _logger.Info($"Received symbols count: {result}");
            var rows = Encoding.UTF8.GetString(buffer, 0, buffer.Length)
                .Split('\n')
                .Select(str => str.Replace("\r", ""))
                .Where(s => !string.IsNullOrEmpty(s));
            if (rows.Count() != 7)
                throw new SchemaException("Rows count should be 7");
            var schema = new SchemaEntity(rows.First().Length);
            var i = 0;
            foreach (var row in rows)
            {
                if (row.Length > 52)
                    throw new SchemaException("Rows length should be less than 53");
                for (var k = 0; k < row.Length; k++)
                {
                    schema.Points[i, k] = (PointType) GetNumericValue(row[k]);
                }
                i++;
            }

            return schema;
        }
    }
}