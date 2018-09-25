using System;
using System.Collections.Generic;
using Autofac;
using FluentAssertions;
using Github.Drawer.Abstractions;
using Github.Drawer.Points;
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
            MockFakeDateTimeProvider.Setup(mock => mock.GetToday()).Returns(new DateTime(2018, 9, 25));
        }

        [Fact]
        public void ReturnCorrectData()
        {
            var schema = CreateEmptySchema();
            schema.Points[0, 0] = PointType.darkest;
            schema.Points[3, 4] = PointType.dusky;

            var points = PointPositionsCalculator.Handle(schema);

            points.Should().BeEquivalentTo(new List<PointPosition>
            {
                new PointPosition(0, 0, Saturation.Deep, new DateTime(2017,9,24)),
                new PointPosition(4, 3, Saturation.MidDeep, new DateTime(2017,10,25))
            });
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