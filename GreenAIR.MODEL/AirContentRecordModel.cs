﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GreenAIR.MODEL
{
    public class  AirContentRecordModel
    {
        public int RecordID { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public string RecognizedGases { get; set; }

        public decimal PollutionLevel { get; set; }
    }
}
