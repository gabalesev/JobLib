// <copyright file="JobLoggerIntelliTest.cs">Copyright ©  2016</copyright>
using System;
using JobLib;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobLib.IntelliTests
{
    /// <summary>This class contains parameterized unit tests for JobLogger</summary>
    [PexClass(typeof(JobLogger))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class JobLoggerIntelliTest
    {
        /// <summary>Test stub for Initialize(Boolean, Boolean, Boolean, EnumLogLevel)</summary>
        [PexMethod]
        public void InitializeIntelliTest(
            bool logToFile,
            bool logToConsole,
            bool logToDatabase,
            EnumLogLevel maxlogLevel
        )
        {
            JobLogger.Initialize(logToFile, logToConsole, logToDatabase, maxlogLevel);
            // TODO: add assertions to method JobLoggerIntelliTest.InitializeIntelliTest(Boolean, Boolean, Boolean, EnumLogLevel)
        }

        /// <summary>Test stub for LogMessage(String, EnumLogLevel)</summary>
        [PexMethod]
        public void LogMessageIntelliTest(string message, EnumLogLevel logLevel)
        {
            JobLogger.LogMessage(message, logLevel);
            // TODO: add assertions to method JobLoggerIntelliTest.LogMessageIntelliTest(String, EnumLogLevel)
        }
    }
}
