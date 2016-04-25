using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace JobLib
{
    public enum EnumLogLevel : int
    {
        Off = 0,                
        Error = 1,
        Warning = 2,
        Message = 3
    }

    public static class JobLogger
    {

        private static bool _logToFile;

        private static bool _logToConsole;

        private static bool _logToDatabase;

        private static EnumLogLevel _maxlogLevel;

        private static bool _initialized = false;

        private static readonly string _logPath;

        private static readonly string _connectionString;

        static JobLogger()
        {
            _logPath = ConfigurationManager.AppSettings["LogFileDirectory"];

            _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public static void Initialize(bool logToFile, bool logToConsole, bool logToDatabase, EnumLogLevel maxlogLevel)
        {
            _maxlogLevel = maxlogLevel;

            _logToDatabase = logToDatabase;

            _logToFile = logToFile;

            _logToConsole = logToConsole;

            _initialized = true;
        }

        public static void LogMessage(string message, EnumLogLevel logLevel)
        {
            if(!_initialized)
                throw new Exception("Not initialized");

            if (message == null || message.Length == 0)
                throw new ArgumentException("Message null or empty"); // didn't inform about what was wrong

            if (!_logToConsole && !_logToFile && !_logToDatabase)
                throw new Exception("Invalid configuration");

            // Disable logging when maximum level of loggin is setted "Off"
            if (_maxlogLevel == EnumLogLevel.Off)
                throw new Exception("Logging disabled");

            // Ensure at the begining of the function, that the level of loging desired of the message is below the maximum level of logging.
            if (logLevel <= _maxlogLevel && logLevel != EnumLogLevel.Off) 
            {
                StringBuilder sb = new StringBuilder();

                message.Trim();
                // We do not need to validate here, since we can not set logLevel with a false or null value
                //if ((!_logError && !_logMessage && !_logWarning) || (!message && !warning && !error))
                //{
                //    throw new Exception("Error or Warning or Message must be specified");
                //}
                if (_logToDatabase)
                {
                    System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString);

                    connection.Open();

                    string strCommand = sb.AppendFormat("Insert into Log Values({0},{1})", message, ((int)logLevel).ToString()).ToString();

                    System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(strCommand);

                    command.ExecuteNonQuery();
                }

                if (_logToFile)
                {
                    string l = String.Empty;

                    sb.Clear();
                    // '/' is not valid for filenames, so string format is used
                    string filePath = sb.AppendFormat(@"{0}{1}{2}{3}", _logPath, "LogFile", DateTime.Now.ToString("yyyyMMdd"), ".txt").ToString();

                    if (File.Exists(filePath)) // Wrong validation
                    {
                        l = File.ReadAllText(filePath);
                    }

                    sb.Clear();

                    // Messages with date and time for more accurate time registry
                    l = sb.AppendFormat("{0}{1} {2}", l, DateTime.Now.ToString("dd/MM/yyyy-H:mm:ss:"), message).AppendLine().ToString();

                    File.WriteAllText(filePath, l);
                }

                if (_logToConsole)
                {
                    sb.Clear();
                    switch(logLevel)
                    {
                        case EnumLogLevel.Error:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case EnumLogLevel.Warning:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case EnumLogLevel.Message:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }

                    Console.WriteLine(sb.AppendFormat("{0} {1}", DateTime.Now.ToString("dd/MM/yyyy-H:mm:ss:"), message).AppendLine().ToString());
                }
            }
        }
    }
}
