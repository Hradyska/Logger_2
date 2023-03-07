using System.Runtime.CompilerServices;

namespace LoggerWithException
{
    public static class FileService
    {
        public static void WriteToFile(string log, string path, string fileName)
        {
            DirectoryInfo(path);
            using StreamWriter sw = new (path + fileName);
            sw.Write(log);
        }

        public static void DirectoryInfo(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo info = new DirectoryInfo(path);
                FileInfo[] fileInfos = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();
                if (fileInfos.Length > 3)
                {
                    fileInfos[0].Delete();
                }
            }
            else
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
