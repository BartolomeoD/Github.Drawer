using System;
using System.IO;
using Github.Drawer.Abstractions;
using Github.Drawer.Helpers;
using Github.Drawer.Schema;
using LibGit2Sharp;

namespace Github.Drawer
{
    public class GithubDrawer : IGithubDrawer
    {
        private readonly ISchemaReader _schemaReader;
        private readonly IPointPositionCalculator _pointPositionCalculator;
        private readonly ICommitCreator _commitCreator;

        public GithubDrawer(
            ISchemaReader schemaReader,
            IPointPositionCalculator pointPositionCalculator,
            ICommitCreator commitCreator
        )
        {
            _schemaReader = schemaReader;
            _pointPositionCalculator = pointPositionCalculator;
            _commitCreator = commitCreator;
        }

        public void Draw(Configuration configuration)
        {
            SchemaEntity schema;
            using (var fileStream = FileManager.OpenFileStream(configuration.SchemaFilePath))
            {
                schema = _schemaReader.Read(fileStream);
            }

            var points = _pointPositionCalculator.Handle(schema);
            if (FileManager.IsExist(configuration.DirectoryPath))
                throw new Exception("Такая папка уже существует");
            FileManager.CreateDirectory(configuration.DirectoryPath);
            FileManager.CopyFile("readme.md", Path.Combine(configuration.DirectoryPath, "readme.md"));
            using (var repo = new Repository(Repository.Init(configuration.DirectoryPath)))
            {
                Commands.Stage(repo, "readme.md");
                var maxCommitsCount = configuration.MaxCommitsCount > 4 ? configuration.MaxCommitsCount : 4;
                _commitCreator.Create(points, repo, maxCommitsCount, configuration.FileName, configuration.UserName,
                    configuration.UserEmail);
            }
        }
    }
}