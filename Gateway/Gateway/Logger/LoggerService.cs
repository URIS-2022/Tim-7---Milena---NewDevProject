using Google.Api;
using Google.Cloud.Logging.Type;
using Google.Cloud.Logging.V2;

namespace Gateway.Logger
{
    public class LoggerService : ILoggerService
    {
        public void WriteLog(string message, string controllerName, LogSeverity severity)
        {
            // Your Google Cloud Platform project ID.
            string projectId = "uris-377509";

            // Instantiates a client.
            var client = LoggingServiceV2Client.Create();

            // Prepare new log entry.
            LogEntry logEntry = new LogEntry();
            string logId = "my-log";
            LogName logName = new LogName(projectId, logId);
            logEntry.LogNameAsLogName = logName;
            logEntry.Severity = severity;

            // Create log entry message.
            string messageId = DateTime.Now.Millisecond.ToString();
            string entrySeverity = logEntry.Severity.ToString().ToUpper();
            logEntry.TextPayload =
                $"{messageId} {entrySeverity} {controllerName} - {message}";

            // Set the resource type to control which GCP resource the log entry belongs to.
            // See the list of resource types at:
            // https://cloud.google.com/logging/docs/api/v2/resource-list
            // This sample uses resource type 'global' causing log entries to appear in the 
            // "Global" resource list of the Developers Console Logs Viewer:
            //  https://console.cloud.google.com/logs/viewer
            MonitoredResource resource = new MonitoredResource
            {
                Type = "global"
            };

            // Create dictionary object to add custom labels to the log entry.
            /*IDictionary<string, string> entryLabels = new Dictionary<string, string>();
            entryLabels.Add("size", "large");
            entryLabels.Add("color", "red");*/

            // Add log entry to collection for writing. Multiple log entries can be added.
            IEnumerable<LogEntry> logEntries = new LogEntry[] { logEntry };

            // Write new log entry.
            client.WriteLogEntries(logName, resource, null, logEntries);
        }
    }
}
