using Github.Drawer.Abstractions;

namespace Github.Drawer
{
    public class GithubDrawer  : IGithubDrawer
    {
        private readonly ISchemaReader _schemaReader;
        private readonly IPointPositionCalculator _pointPositionCalculator;
        private readonly ICommandCreator _commandCreator;
        private readonly ICommandExecutor _commandExecutor;

        public GithubDrawer(
            ISchemaReader schemaReader,
            IPointPositionCalculator pointPositionCalculator,
            ICommandCreator commandCreator,
            ICommandExecutor commandExecutor
        )
        {
            _schemaReader = schemaReader;
            _pointPositionCalculator = pointPositionCalculator;
            _commandCreator = commandCreator;
            _commandExecutor = commandExecutor;
        }

        public void Draw(string filePath)
        {

        }
    }
}
