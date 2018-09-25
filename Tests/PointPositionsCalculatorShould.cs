using Autofac;
using Github.Drawer.Abstractions;
using Github.Drawer.Schema;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class PointPositionsCalculatorShould : BaseTest
    {
        protected IPointPositionCalculator PointPositionsCalculator;

        public PointPositionsCalculatorShould(ITestOutputHelper outputHelper) : base(outputHelper)
        {
            PointPositionsCalculator = Container.Resolve<IPointPositionCalculator>();
        }

        [Fact]
        public void Test()
        {
            var schema = CreateEmptySchema();
            schema.Points[0, 0] = PointType.darkest;
            schema.Points[3, 4] = PointType.dusky;

            var points = PointPositionsCalculator.Handle(schema);
            foreach (var pointPosition in points)
            {
                Output.WriteLine(pointPosition.ToString());
            }
        }

        private static SchemaEntity CreateEmptySchema()
        {
            var schema = new SchemaEntity();
            for (var weekIndex = 0; weekIndex < schema.Points.GetLength(1); weekIndex++)
            {
                for (var dayIndex = 0; dayIndex < 7; dayIndex++)
                {
                    schema.Points[dayIndex, weekIndex] = PointType.empty;
                }
            }

            return schema;
        }
    }
}
