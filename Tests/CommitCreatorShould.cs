using System;
using System.Collections.Generic;
using Autofac;
using Github.Drawer.Abstractions;
using Github.Drawer.Helpers;
using Github.Drawer.Points;
using LibGit2Sharp;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class CommitCreatorShould : BaseTest
    {
        protected ICommitCreator CommitCreator;

        public CommitCreatorShould(ITestOutputHelper output) : base(output)
        {
            CommitCreator = Container.Resolve<ICommitCreator>();
        }

        [Fact(Skip = "Для ручного тестирования")]
        public void CreateRepositoryWithCommits()
        {
            var points = new List<PointPosition>
            {
                new PointPosition(0, 0, Saturation.Light, new DateTime(2017, 9, 24))
            };

            const string workingDirectoryPath = "test";
            if (FileManager.IsExist(workingDirectoryPath))
                FileManager.RemoveDirectory(workingDirectoryPath);
            FileManager.CreateDirectory(workingDirectoryPath);
            using (var repo = new Repository(Repository.Init(workingDirectoryPath)))
            {
                CommitCreator.Create(points, repo, 4, "test_file.txt", "TestUserName", "test@test.ru");
            }
        }
    }
}