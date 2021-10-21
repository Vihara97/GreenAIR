using GreenAIR.MODELS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;

namespace GreenAIR.Common
{
    public class CommonMethod
    {
        public List<ComboDTO> getEnumDescription<T>()
        {
            List<ComboDTO> oData = new List<ComboDTO>();
            try
            {
                foreach (IConvertible e in Enum.GetValues(typeof(T)))
                {
                    string text = e.ToString().Trim();
                    string value = e.ToType(Enum.GetUnderlyingType(typeof(T)), CultureInfo.CurrentCulture).ToString();
                    var attributes = typeof(T).GetField(text.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                    string Description = attributes.Length == 0 ? text : ((DescriptionAttribute)attributes[0]).Description.ToString();
                    oData.Add(new ComboDTO { Value = value, Text = Description });
                }
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ComboDTO> getEnumDescriptionWithSelect<T>()
        {
            List<ComboDTO> oData = new List<ComboDTO>();
            try
            {
                oData.Add(new ComboDTO { Text = "- Select -" });
                foreach (IConvertible e in Enum.GetValues(typeof(T)))
                {
                    string text = e.ToString().Trim();
                    string value = e.ToType(Enum.GetUnderlyingType(typeof(T)), CultureInfo.CurrentCulture).ToString();
                    var attributes = typeof(T).GetField(text.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                    string Description = attributes.Length == 0 ? text : ((DescriptionAttribute)attributes[0]).Description.ToString();
                    oData.Add(new ComboDTO { Value = value, Text = Description });
                }
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ComboDTO> getEnumDescriptionWithOutSelect<T>()
        {
            List<ComboDTO> oData = new List<ComboDTO>();
            try
            {
                foreach (IConvertible e in Enum.GetValues(typeof(T)))
                {
                    string text = e.ToString().Trim();
                    string value = e.ToType(Enum.GetUnderlyingType(typeof(T)), CultureInfo.CurrentCulture).ToString();
                    var attributes = typeof(T).GetField(text.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                    string Description = attributes.Length == 0 ? text : ((DescriptionAttribute)attributes[0]).Description.ToString();
                    oData.Add(new ComboDTO { Value = value, Text = Description });
                }
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public string GetPasswordResetMessage(string name, string userID, string password)
        {
            throw new System.NotImplementedException();
        }

        public List<ComboDTO> ComboDataBindByEnum<T>()
        {
            List<ComboDTO> oData = new List<ComboDTO>();
            try
            {
                oData.Add(new ComboDTO { Text = "- Select -", Value = "" });
                foreach (IConvertible e in Enum.GetValues(typeof(T)))
                {
                    string text = e.ToString().Trim();
                    string value = e.ToType(Enum.GetUnderlyingType(typeof(T)), CultureInfo.CurrentCulture).ToString();
                    var attributes = typeof(T).GetField(text.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                    string Description = attributes.Length == 0 ? text : ((DescriptionAttribute)attributes[0]).Description.ToString();
                    oData.Add(new ComboDTO { Value = value, Text = Description });
                }
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ComboDTO> ComboDataBindByEnum<T>(string selectString)
        {
            List<ComboDTO> oData = new List<ComboDTO>();
            try
            {
                oData.Add(new ComboDTO { Text = selectString, Value = "" });
                foreach (IConvertible e in Enum.GetValues(typeof(T)))
                {
                    string text = e.ToString().Trim();
                    string value = e.ToType(Enum.GetUnderlyingType(typeof(T)), CultureInfo.CurrentCulture).ToString();
                    var attributes = typeof(T).GetField(text.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                    string Description = attributes.Length == 0 ? text : ((DescriptionAttribute)attributes[0]).Description.ToString();
                    oData.Add(new ComboDTO { Value = value, Text = Description });
                }
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ComboDTO> ComboDataBindByEnumhh()
        {
            List<ComboDTO> oData = new List<ComboDTO>();
            try
            {
                oData.Add(new ComboDTO { Text = "HH", Value = "" });

                for (int i = 0; i < 24; i++)
                {
                    string time = Convert.ToString(i).PadLeft(2, '0');
                    oData.Add(new ComboDTO { Value = time, Text = time });
                }
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ComboDTO> ComboDataBindByEnumMM()
        {
            List<ComboDTO> oData = new List<ComboDTO>();
            try
            {
                oData.Add(new ComboDTO { Text = "MM", Value = "" });

                for (int i = 0; i < 60; i++)
                {
                    string time = Convert.ToString(i).PadLeft(2, '0');
                    oData.Add(new ComboDTO { Value = time, Text = time });
                }
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ComboDTO> ComboDataDateOfMonth()
        {
            List<ComboDTO> oData = new List<ComboDTO>();
            try
            {
                oData.Add(new ComboDTO { Text = "DD", Value = "" });
                for (int i = 0; i <= 31; i++)
                {
                    string date = Convert.ToString(i).PadLeft(2, '0');
                    oData.Add(new ComboDTO { Value = date, Text = date });
                }
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ComboDTO> ComboDataBindHH()
        {
            List<ComboDTO> oData = new List<ComboDTO>();
            try
            {
                for (int i = 0; i < 24; i++)
                {
                    string time = Convert.ToString(i).PadLeft(2, '0');
                    oData.Add(new ComboDTO { Value = time, Text = time });
                }
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ComboDTO> ComboDataBindMM()
        {
            List<ComboDTO> oData = new List<ComboDTO>();
            try
            {
                oData.Add(new ComboDTO { Value = "0", Text = "00" });
                oData.Add(new ComboDTO { Value = "30", Text = "30" });
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ConvertHundredMinutesToMinutes(string time)
        {
            decimal minutes = Convert.ToDecimal(time);
            decimal hundred = minutes / 100;
            decimal retval = hundred * 60;

            return Convert.ToInt32(retval);
        }

        public static int ConvertHundredTimetoMinutes(decimal time)
        {
            int hour = 0;
            int minutes = 0;

            hour = Convert.ToInt32(time.ToString().Split('.')[0]);

            if (time.ToString().Contains("."))
                minutes = Convert.ToInt32(time.ToString().Split('.')[1]);

            return (hour * 60) + ConvertHundredMinutesToMinutes((minutes * 10).ToString());
        }

        public static int ConvertMinutesToHundredMinutes(int minutepart)
        {
            decimal minutes = Convert.ToDecimal(minutepart);
            decimal a = minutes / 60;
            int b = Convert.ToInt32(a * 100);

            return b;
        }

        public static decimal ConvertMinutesToHundredTime(decimal totalminutes)
        {
            int hours = Convert.ToInt32(totalminutes) / 60;
            decimal minutes = totalminutes % 60;
            decimal a = minutes / 60;
            decimal b = a * 100;
            int hundred = Convert.ToInt32(b);
            string time = hours.ToString() + "." + hundred.ToString();
            return Convert.ToDecimal(time);
        }
    }
}