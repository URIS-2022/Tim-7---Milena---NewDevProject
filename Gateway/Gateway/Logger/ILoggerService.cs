using Google.Cloud.Logging.Type;

namespace Gateway.Logger
{
    public interface ILoggerService
    {
        public void WriteLog(string message, string controllerName, LogSeverity severity);
    }
}
