using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenAIR.MODELS
{
    public class MonitoringCenterModel
    {
        public int CenterID { get; set; }

        public string Name { get; set; }

        public int Location { get; set; }

        public int Status { get; set; }
    }
}