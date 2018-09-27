using System.IO;

namespace Github.Drawer.Helpers
{
    public static class FileManager 
    {
        public static void CreateDirectory(string directoryName)
        {
            Directory.CreateDirectory(directoryName);
        }

        public static void CreateFile(string filePath)
        {
            File.Create(filePath);
        }

        public static void Rewrite(string filePath, string content)
        {
            using (var tw = new StreamWriter(filePath, false))
            {
                tw.Write(content);
            }
        }

        public static FileStream OpenFileStream(string filePath)
        {
            return File.OpenRead(filePath);
        }
    }
}
