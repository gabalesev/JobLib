﻿using JobLib;
using System;

namespace TestUnit1
{
    class Program
    {
        static void Main(string[] args)
        {
            JobLogger.Initialize(true, true, false, EnumLogLevel.Message);

            JobLogger jb = new JobLogger();
            JobLogger.LogMessage("Off", EnumLogLevel.Off);

            JobLogger.LogMessage("Mensaje 2", EnumLogLevel.Message);

            JobLogger.LogMessage("Warning 1", EnumLogLevel.Warning);

            JobLogger.LogMessage("Error 1", EnumLogLevel.Error);
            JobLogger.LogMessage("Error 2", EnumLogLevel.Error);

        }
    }
}
