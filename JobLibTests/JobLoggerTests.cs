using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobLib.Tests
{
    [TestClass()]
    public class JobLoggerTests
    {
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void LogMessageNotInitializedTest()
        {
            JobLogger.LogMessage("Mensaje 1", EnumLogLevel.Message);            
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void LogMessageMessageNullOrEmptyTest()
        {
            JobLogger.Initialize(true, true, true, EnumLogLevel.Message);

            JobLogger.LogMessage("", EnumLogLevel.Message);
        }
    }
}