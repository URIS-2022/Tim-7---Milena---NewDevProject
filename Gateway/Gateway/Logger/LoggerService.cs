using Google.Api;
using Google.Cloud.Logging.Type;
using Google.Cloud.Logging.V2;

namespace Gateway.Logger
{
    public class LoggerService : ILoggerService
    {
        public void WriteLog(string message, string controllerName, LogSeverity severity)
        {
            string projectId = "uris-377509";

            var client = LoggingServiceV2Client.Create();

            LogEntry logEntry = new LogEntry();
            string logId = "my-log";
            LogName logName = new LogName(projectId, logId);
            logEntry.LogNameAsLogName = logName;
            logEntry.Severity = severity;

            string messageId = DateTime.Now.Millisecond.ToString();
            string entrySeverity = logEntry.Severity.ToString().ToUpper();
            logEntry.TextPayload =
                $"{messageId} {entrySeverity} {controllerName} - {message}";

            MonitoredResource resource = new MonitoredResource
            {
                Type = "global"
            };

            IEnumerable<LogEntry> logEntries = new LogEntry[] { logEntry };

            client.WriteLogEntries(logName, resource, null, logEntries);
        }
    }
}
