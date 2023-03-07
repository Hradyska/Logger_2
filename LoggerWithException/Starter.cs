using System.Text.Json;
using static LoggerWithException.Actions;
namespace LoggerWithException
{
    internal static class Starter
    {
        public static void Run()
        {
            int j;
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                bool flag = false;
                j = rand.Next(0, 100);
                if (j < 30)
                {
                    j = 0;
                }
                else if (j >= 30 && j < 60)
                {
                    j = 1;
                }
                else
                {
                    j = 2;
                }

                try
                {
                    switch (j)
                    {
                        case 0:
                            flag = Info();
                            break;
                        case 1:
                            flag = Warning();
                            break;
                        case 2:
                            flag = Error();
                            break;
                    }
                }
                catch (BusinessException e)
                {
                    Logwriter.WriteLog(e.ErrorTime, LogType.Warning, "Action got this custom Exception: " + e.ExMessage + " " + e.TargetSite);
                }
                catch (Exception e)
                {
                    Logwriter.WriteLog(DateTime.Now, LogType.Error, "Action failed by reason: " + e.Message + " " + e.ToString());
                }

                if (flag)
                {
                    Logwriter.WriteLog(DateTime.Now, LogType.Info, $"Start method: {nameof(Actions.Info)}");
                }
            }

            string configFile = File.ReadAllText("config.json");
            Config config = JsonSerializer.Deserialize<Config>(configFile);
            string path = config.GetLogConfig.Path;
            string fileName = $"{DateTime.Now.ToString(config.GetLogConfig.TimeFormat)}" + config.GetLogConfig.LogName;
            Logwriter.WriteLogToFile(path, fileName);
        }
    }
}
