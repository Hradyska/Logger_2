using System.Text.Json;
using System.Text.Json.Serialization;

namespace LoggerWithException
{
    public static class Config
    {
        public static LogConfig GetLogConfig { get; set; }
        public static void Serialization()
        {
            string configFile = File.ReadAllText("config.json");
            GetLogConfig = JsonSerializer.Deserialize<LogConfig>(configFile);
        }
    }
}