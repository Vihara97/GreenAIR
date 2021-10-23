using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenAIR.MODELS
{
    public class VegitationModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Species { get; set; }

        public int HowManyPerUnit { get; set; }
    }
}