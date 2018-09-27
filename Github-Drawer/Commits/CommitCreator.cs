using System.Collections.Generic;
using System.IO;
using Github.Drawer.Abstractions;
using Github.Drawer.Helpers;
using Github.Drawer.Points;
using LibGit2Sharp;

namespace Github.Drawer.Commits
{
    public class CommitCreator : ICommitCreator
    {
        private readonly ILogger _logger;

        public CommitCreator(ILogger logger)
        {
            _logger = logger;
        }

        public void Create(IEnumerable<PointPosition> points, Repository repository, int maxCommitsCount,
            string fileName, string userName,
            string userEmail)
        {
            var saturationCommitsCount = new Dictionary<Saturation, int>
            {
                {Saturation.Deep, maxCommitsCount},
                {Saturation.MidDeep, maxCommitsCount / 4 * 3},
                {Saturation.MidLight, maxCommitsCount / 4 * 2},
                {Saturation.Light, maxCommitsCount / 4}
            };

            var commitNumber = 0;
            foreach (var pointPosition in points)
            {
                for (var i = 0; i < saturationCommitsCount[pointPosition.Saturation]; i++)
                {
                    FileManager.Rewrite(Path.Combine(repository.Info.WorkingDirectory, fileName),
                        $"Commit #{commitNumber}");
                    Commands.Stage(repository, fileName);
                    var signature = new Signature(userName, userEmail, pointPosition.CommitDateTime);
                    repository.Commit($"Commit #{commitNumber}", signature, signature);
                    commitNumber++;
                }
            }

            _logger.Info($"Successfully created {commitNumber}");
        }
    }
}