using System.Text;

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

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(MaxCommitsCount.ToString()).Append("\n");
            stringBuilder.Append(UserName).Append("\n");
            stringBuilder.Append(UserEmail).Append("\n");
            stringBuilder.Append(DirectoryPath).Append("\n");
            stringBuilder.Append(SchemaFilePath).Append("\n");
            stringBuilder.Append(FileName).Append("\n");

            return stringBuilder.ToString();
        }
    }
}
