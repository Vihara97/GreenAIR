using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenAIR.Common
{
    public class ResponseMessages
    {
        public static string InsertSuccess { get { return "Record Successfully Inserted."; } }

        public static string UpdateSuccess { get { return "Record Successfully Updated."; } }

        public static string UpdateFailed { get { return "Update failed. "; } }

        public static string DeleteFailed { get { return "Delete failed. "; } }

        public static string DeleteSuccess { get { return "Record Successfully Deleted."; } }

        public static string InactivateSuccess { get { return "Record Successfully Inactivated."; } }

        public static string Failure { get { return "Something went wrong."; } }

        public static string ExistRecodeDeleteFail { get { return "Cannot delete,Since this recode has been already used in another level"; } }

        internal static string RecordNotExist { get { return "Record Not Exist. ! "; } }
    }
}