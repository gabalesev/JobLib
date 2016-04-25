using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobLib;
using System;

namespace JobLib.Tests
{
    [TestClass]
    public class JobLoggerTests
    {
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

        // In order to pass this test create folder C:\Logs or delete LogFileDirectory key from App.config for save LogFiles in project folder
        [TestMethod]
        public void LogMessagesToFileTest()
        {
            JobLogger.Initialize(true, false, false, EnumLogLevel.Message);

            JobLogger.LogMessage("Mensaje", EnumLogLevel.Message);

            JobLogger.LogMessage("Warning", EnumLogLevel.Warning);

            JobLogger.LogMessage("Error", EnumLogLevel.Error);
        }

        [TestMethod]
        public void LogMessagesToConsoleTest()
        {
            JobLogger.Initialize(false, true, false, EnumLogLevel.Message);

            JobLogger.LogMessage("Mensaje", EnumLogLevel.Message);

            JobLogger.LogMessage("Warning", EnumLogLevel.Warning);

            JobLogger.LogMessage("Error", EnumLogLevel.Error);
        }

        [TestMethod]
        public void LogMessagesToDataBaseTest()
        {
            JobLogger.Initialize(false, false, true, EnumLogLevel.Message);

            JobLogger.LogMessage("Mensaje", EnumLogLevel.Message);

            JobLogger.LogMessage("Warning", EnumLogLevel.Warning);

            JobLogger.LogMessage("Error", EnumLogLevel.Error);
        }
    }
}