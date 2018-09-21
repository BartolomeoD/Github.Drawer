using System.Text;

namespace Github.Drawer.Schema
{
    public class SchemaEntity
    {
        public PointType[,] Points { get; }

        protected int Height = 7;

        public SchemaEntity(int schemaLength = 52)
        {
            Points = new PointType[7, schemaLength];
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < this.Points.GetLength(1); j++)
                {
                    stringBuilder.Append((int) Points[i, j]);
                }
                stringBuilder.Append('\n');
            }
            return stringBuilder.ToString();
        }
    }
}