using System.Text.Json;
using System.Text.Json.Serialization;

namespace LoggerWithException
{
    public class Config
    {
        public LogConfig GetLogConfig { get; set; }
    }
}