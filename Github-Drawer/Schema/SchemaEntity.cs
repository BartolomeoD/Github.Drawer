namespace Github.Drawer.Schema
{
    public class SchemaEntity
    {
        public PointType[,] Points { get; }

        public SchemaEntity(int schemaLength = 52)
        {
            Points = new PointType[7,schemaLength];
        }
    }
}
