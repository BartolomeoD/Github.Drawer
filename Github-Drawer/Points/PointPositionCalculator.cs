using System;
using System.Collections.Generic;
using Github.Drawer.Abstractions;
using Github.Drawer.Schema;

namespace Github.Drawer.Points
{
    public class PointPositionCalculator : IPointPositionCalculator
    {
        private readonly int _supposedWeeksCountInGithubTable = 53;

        private readonly ILogger _logger;

        public PointPositionCalculator(ILogger logger)
        {
            _logger = logger;
        }

        public IEnumerable<PointPosition> Handle(SchemaEntity schema)
        {
            var now = DateTime.Today;
            var supposedDaysInGithubTable = _supposedWeeksCountInGithubTable * 7;
            var supposedWeek = now.AddDays(-supposedDaysInGithubTable);
            _logger.Info($"Supposed last week hidden in github table: {supposedWeek.ToLongTimeString()}");
            var startTableDay = FindNextDateByDayOfWeek(supposedWeek, DayOfWeek.Sunday);
            _logger.Info($"Start table day: {startTableDay.ToLongTimeString()}");

            var pointsPositions = new List<PointPosition>();
            var currentDay = startTableDay;
            for (var weekIndex = 0; weekIndex < schema.Points.GetLength(1); weekIndex++)
            {
                for (var dayIndex = 0; dayIndex < 7; dayIndex++)
                {
                    if (schema.Points[dayIndex, weekIndex] != PointType.empty)
                    {
                        var point = new PointPosition(weekIndex, dayIndex,
                            (Saturation) schema.Points[dayIndex, weekIndex] - 1, currentDay);
                        pointsPositions.Add(point);
                    }

                    currentDay = currentDay.AddDays(1);
                }
            }

            return pointsPositions;
        }

        private static DateTime FindNextDateByDayOfWeek(DateTime startFrom, DayOfWeek dayOfWeek)
        {
            var operatingDate = startFrom;
            while (operatingDate.DayOfWeek != dayOfWeek)
                operatingDate = operatingDate.AddDays(1);
            return operatingDate;
        }
    }
}