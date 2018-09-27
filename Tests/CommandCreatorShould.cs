using System;
using System.Collections.Generic;
using Autofac;
using Github.Drawer.Abstractions;
using Github.Drawer.Points;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class CommandCreatorShould : BaseTest
    {
        protected ICommitCreator CommitCreator;

        public CommandCreatorShould(ITestOutputHelper output) : base(output)
        {
            CommitCreator = Container.Resolve<ICommitCreator>();
        }

        [Fact]
        public void Test()
        {
            var points = new List<PointPosition>
            {
                new PointPosition(0, 0, Saturation.Deep, new DateTime(2018, 9, 25)),
                new PointPosition(0, 1, Saturation.Deep, new DateTime(2018, 9, 26)),
                new PointPosition(0, 2, Saturation.Deep, new DateTime(2018, 9, 27)),
                new PointPosition(0, 3, Saturation.Deep, new DateTime(2018, 9, 28)),
            };

            //var result = CommitCreator.Create(points);

            //foreach (var terminalCommand in result)
            //{
            //    Output.WriteLine(terminalCommand.ToString());
            //}
        }
    }
}