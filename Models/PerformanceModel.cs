using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PerformanceMonitor.Models
{
    public class PerformanceModel
    {
        public string dateTime { get; set; }
        public decimal cpuUsage { get; set; }
        public decimal memoryUsage { get; set; }

    }
}