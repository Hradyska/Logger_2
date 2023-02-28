namespace LoggerWithException
{
    public static class Logwriter
    {
        public static string Log
        {
            get;
            private set;
        }

        public static void WriteLog(DateTime time, LogType type, string message)
        {
            Log += $"{Environment.NewLine}{time.ToString("hh.mm.ss. dd.MM.yyyy")}: {type}: {message}";
        }

        public static void WriteToFile()
        {
            FileService.StreamWriter(Log);
        }
    }
}
