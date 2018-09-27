namespace Github.Drawer
{
    public class Configuration
    {
        public Configuration()
        {

        }

        public Configuration(int maxCommitsCount, string fileName, string directoryPath)
        {
            MaxCommitsCount = maxCommitsCount;
            FileName = fileName;
            DirectoryPath = directoryPath;
        }

        public string SchemaFilePath { get; set; }
        public int MaxCommitsCount { get; set; }
        public string FileName { get; set; }
        public string DirectoryPath { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
    }
}
