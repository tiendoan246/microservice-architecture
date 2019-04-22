using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Common.Config
{
    public class AppSettings
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public EventStore EventStore { get; set; }
    }

    public class EventStore
    {
        public int Port { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
    }
}
