using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenAIR.MODELS
{
    public class UserModel
    {
        public int UserID { get; set; }

        public string Name { get; set; }

        public int LocationAddress { get; set; }

        public string MobileNoOrEmail { get; set; }

        public string Password { get; set; }

        public int Status { get; set; }
    }
}