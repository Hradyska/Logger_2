using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerWithException
{
    internal static class FileService
    {
        private static string _path = string.Empty;
        private static string _fileName = string.Empty;

        static FileService()
        {
            _path = Path;
            _fileName = FileName;
        }

        public static string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
            }
        }

        public static string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
            }
        }

        public static void StreamWriter(string log)
        {
            DirectoryInfo();
            using StreamWriter sw = new (_path + _fileName);
            sw.Write(log);
        }

        public static void DirectoryInfo()
        {
            if (Directory.Exists(_path))
            {
                DirectoryInfo info = new DirectoryInfo(_path);
                FileInfo[] fileInfos = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();
                if (fileInfos.Length > 3)
                {
                    fileInfos[0].Delete();
                }
            }
            else
            {
                Directory.CreateDirectory(_path);
            }
        }
    }
}
