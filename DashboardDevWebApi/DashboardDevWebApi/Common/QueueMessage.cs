using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DashboardDevWebApi.Common
{
    public class QueueMessage
    {
        public string ActionType { get; internal set; }
        public string CCN { get; set; }
        public string ReportingQId { get; set; }
    }
}