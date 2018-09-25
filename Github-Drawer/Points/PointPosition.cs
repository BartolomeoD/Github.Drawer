using System;

namespace Github.Drawer.Points
{
    public class PointPosition
    {
        public int X { get; }
        public int Y { get; }
        public Saturation Saturation { get; }
        public DateTime CommitDateTime { get; }

        public PointPosition(int x, int y, Saturation saturation, DateTime commitDateTime)
        {
            X = x;
            Y = y;
            Saturation = saturation;
            CommitDateTime = commitDateTime;
        }

        public override string ToString()
        {
            return $"x: {X}, y: {Y}, Saturation: {Saturation}, Commit date: {CommitDateTime.ToShortDateString()}";
        }
    }
}
