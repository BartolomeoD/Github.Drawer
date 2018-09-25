using System.Collections.Generic;
using Github.Drawer.Abstractions;
using Github.Drawer.Points;

namespace Github.Drawer.Command
{
    public class CommandCreator : ICommandCreator
    {
        private readonly Configuration _configuration;
        private readonly Dictionary<Saturation, int> _saturationCommitsCounts;

        public CommandCreator(Configuration configuration)
        {
            _configuration = configuration;
            var maxCommitsCount = configuration.MaxCommitsCount > 4 ? configuration.MaxCommitsCount : 4;
            _saturationCommitsCounts = new Dictionary<Saturation, int>
            {
                {Saturation.Light, maxCommitsCount / 4 * 1},
                {Saturation.MidLight, maxCommitsCount / 4 * 2},
                {Saturation.MidDeep, maxCommitsCount / 4 * 3},
                {Saturation.Deep, maxCommitsCount},
            };
        }

        public IEnumerable<TerminalCommand> Create(IEnumerable<PointPosition> points)
        {
            var commands = new List<TerminalCommand>();
            var commentNumber = 0;
            foreach (var pointPosition in points)
            {
                for (var i = 0; i < _saturationCommitsCounts[pointPosition.Saturation]; i++)
                {
                    commentNumber++;
                    commands.Add(
                        new TerminalCommand("git", new Dictionary<string, string>
                        {
                            {"message", $"Commit #{commentNumber}"},
                            {"date", pointPosition.CommitDateTime.ToString("o")}
                        }));
                }
            }

            return commands;
        }
    }
}