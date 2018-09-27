using System.Collections.Generic;
using Github.Drawer.Points;
using LibGit2Sharp;

namespace Github.Drawer.Abstractions
{
    public interface ICommitCreator
    {
        void Create(IEnumerable<PointPosition> points, Repository repository, int maxCommitsCount, string fileName,
            string userName, string userEmail);
    }
}
