using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobLib;
using System;

namespace JobLib.Tests
{
    [TestClass]
    public class JobLoggerTests
    {
        #region EXPECTED EXCEPTIONS
        [TestMethod]
        [ExpectedException(typeof(Exception), "Logging disabled")]
        public void LogMessageLogDisabledTest()
        {
            JobLogger.Initialize(true, true, true, EnumLogLevel.Off);
            JobLogger.LogMessage("Mensaje", EnumLogLevel.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Not initialized")]
        public void LogMessageNotInitializedTest()
        {
            JobLogger.LogMessage("Mensaje", EnumLogLevel.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Message null or empty")]
        public void LogMessageMessageNullOrEmptyTest()
        {
            JobLogger.Initialize(true, true, true, EnumLogLevel.Message);

            JobLogger.LogMessage("", EnumLogLevel.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid configuration")]
        public void LogMessageInvalidConfigTest()
        {
            JobLogger.Initialize(false, false, false, EnumLogLevel.Message);

            JobLogger.LogMessage("Mensaje", EnumLogLevel.Message);
        }
        #endregion

        
        [TestMethod]
        public void LogToFileTest_MessageConfig()
        {
            // In order to pass this test create folder C:\Logs or delete LogFileDirectory key 
            // from App.config to save LogFiles in project folder

            JobLogger.Initialize(true, false, false, EnumLogLevel.Message);

            JobLogger.LogMessage("Mensaje", EnumLogLevel.Message); // Should log

            JobLogger.LogMessage("Warning", EnumLogLevel.Warning); // Should log

            JobLogger.LogMessage("Error", EnumLogLevel.Error); // Should log
        }

        [TestMethod]
        public void LogToConsoleTest_MessageConfig()
        {
            JobLogger.Initialize(false, true, false, EnumLogLevel.Message);

            JobLogger.LogMessage("Mensaje", EnumLogLevel.Message); // Should log

            JobLogger.LogMessage("Warning", EnumLogLevel.Warning); // Should log

            JobLogger.LogMessage("Error", EnumLogLevel.Error); // Should log
        }

        [TestMethod]
        public void LogToDataBaseTest_MessageConfig()
        {
            JobLogger.Initialize(false, false, true, EnumLogLevel.Message);

            JobLogger.LogMessage("Mensaje", EnumLogLevel.Message); // Should log

            JobLogger.LogMessage("Warning", EnumLogLevel.Warning); // Should log

            JobLogger.LogMessage("Error", EnumLogLevel.Error); // Should log
        }

        [TestMethod]
        public void LogToFileTest_WarningConfig()
        {
            // In order to pass this test create folder C:\Logs or delete LogFileDirectory key 
            // from App.config to save LogFiles in project folder

            JobLogger.Initialize(true, false, false, EnumLogLevel.Warning);

            JobLogger.LogMessage("Mensaje", EnumLogLevel.Message); // Shouldn't log

            JobLogger.LogMessage("Warning", EnumLogLevel.Warning); // Should log

            JobLogger.LogMessage("Error", EnumLogLevel.Error); // Should log
        }

        [TestMethod]
        public void LogToConsoleTest_WarningConfig()
        {
            JobLogger.Initialize(false, true, false, EnumLogLevel.Warning);

            JobLogger.LogMessage("Mensaje", EnumLogLevel.Message); // Shouldn't log

            JobLogger.LogMessage("Warning", EnumLogLevel.Warning); // Should log

            JobLogger.LogMessage("Error", EnumLogLevel.Error); // Should log
        }

        [TestMethod]
        public void LogToDataBaseTest_WarningConfig()
        {
            JobLogger.Initialize(false, false, true, EnumLogLevel.Warning);

            JobLogger.LogMessage("Mensaje", EnumLogLevel.Message); // Shouldn't log

            JobLogger.LogMessage("Warning", EnumLogLevel.Warning); // Should log

            JobLogger.LogMessage("Error", EnumLogLevel.Error); // Should log
        }

        [TestMethod]
        public void LogToFileTest_ErrorConfig()
        {
            // In order to pass this test create folder C:\Logs or delete LogFileDirectory key 
            // from App.config to save LogFiles in project folder

            JobLogger.Initialize(true, false, false, EnumLogLevel.Error);

            JobLogger.LogMessage("Mensaje", EnumLogLevel.Message); // Shouldn't log

            JobLogger.LogMessage("Warning", EnumLogLevel.Warning); // Shouldn't log

            JobLogger.LogMessage("Error", EnumLogLevel.Error); // Should log
        }

        [TestMethod]
        public void LogToConsoleTest_ErrorConfig()
        {
            JobLogger.Initialize(false, true, false, EnumLogLevel.Error);

            JobLogger.LogMessage("Mensaje", EnumLogLevel.Message); // Shouldn't log

            JobLogger.LogMessage("Warning", EnumLogLevel.Warning); // Shouldn't log

            JobLogger.LogMessage("Error", EnumLogLevel.Error); // Should log
        }

        [TestMethod]
        public void LogToDataBaseTest_ErrorConfig()
        {
            JobLogger.Initialize(false, false, true, EnumLogLevel.Error);

            JobLogger.LogMessage("Mensaje", EnumLogLevel.Message); // Shouldn't log

            JobLogger.LogMessage("Warning", EnumLogLevel.Warning); // Shouldn't log

            JobLogger.LogMessage("Error", EnumLogLevel.Error); // Should log
        }

        [TestMethod]
        public void LogToFileTest_OffConfig()
        {
            JobLogger.Initialize(true, false, false, EnumLogLevel.Error);

            JobLogger.LogMessage("Mensaje", EnumLogLevel.Message); // Shouldn't log

            JobLogger.LogMessage("Warning", EnumLogLevel.Warning); // Shouldn't log

            JobLogger.LogMessage("Error", EnumLogLevel.Error); // Shouldn't log
        }

        [TestMethod]
        public void LogToConsoleTest_OffConfig()
        {
            JobLogger.Initialize(false, true, false, EnumLogLevel.Error);

            JobLogger.LogMessage("Mensaje", EnumLogLevel.Message); // Shouldn't log

            JobLogger.LogMessage("Warning", EnumLogLevel.Warning); // Shouldn't log

            JobLogger.LogMessage("Error", EnumLogLevel.Error); // Shouldn't log
        }

        [TestMethod]
        public void LogToDataBaseTest_OffConfig()
        {
            JobLogger.Initialize(false, false, true, EnumLogLevel.Error);

            JobLogger.LogMessage("Mensaje", EnumLogLevel.Message); // Shouldn't log

            JobLogger.LogMessage("Warning", EnumLogLevel.Warning); // Shouldn't log

            JobLogger.LogMessage("Error", EnumLogLevel.Error); // Shouldn't log
        }
    }
}