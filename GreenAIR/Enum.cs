using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GreenAIR
{
    public enum Locations
    {
        [Description("Colombo")]
        Colombo = 1,

        [Description("Dehiwala-Mount Lavinia")]
        DehiwalaMountLavinia = 2,

        [Description("Sri Jayawardenapura Kotte")]
        SriJayawardenapuraKotte = 3,

        [Description("Kaduwela")]
        Kaduwela = 4,

        [Description("Moratuwa")]
        Moratuwa = 5,

        [Description("Negombo")]
        Negombo = 6,

        [Description("Gampaha")]
        Gampaha = 7,

        [Description("Panadura")]
        Panadura = 8,

        [Description("Horana")]
        Horana = 9,

        [Description("Kalutara")]
        Kalutara = 10,

        [Description("Beruwala")]
        Beruwala = 11
    }

    public enum WarningType
    {
        Success = 1,
        Info = 2,
        Warning = 3,
        Danger = 4
    }

    public enum CommandMood
    {
        Add = 1,
        Edit = 2,
        View = 3,
        clear = 4,
        pageload = 5
    }

    public enum Status
    {
        Active = 1,
        Inactive = 2
    }
}