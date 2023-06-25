using NHCH.ULT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;

namespace NHCH.ULT
{
    public class Format
    {
        public static object GetValueParm(object value)
        {
            if (value is int)
            {
                return (int)value == 0 ? DBNull.Value : value;
            }
            else if (value is DateTime)
            {
                return (DateTime)value == DateTime.MinValue ? DBNull.Value : value;
            }
            else
                return value;
        }
        public static String FormatDate(DateTime dt)
        {
            if (dt == DateTime.MinValue)
            {
                return String.Empty;
            }
            return dt.ToString("dd/MM/yyyy");
        }
        public static String FormatDate_Hour(DateTime dt)
        {
            if (dt == DateTime.MinValue)
            {
                return String.Empty;
            }
            return dt.ToString("dd/MM/yyyy hh:mm:ss");
        }
        public static string FormatDateGoTime(DateTime dt)
        {
            if (dt == DateTime.MinValue)
            {
                return string.Empty;
            }
            return dt.ToString("dd/MM/yyy hh:mm:ss tt");
        }
        public static String FormatDate(string dt)
        {
            return Convert.ToDateTime(dt).ToString("dd/MM/yyyy");
        }

        public static String FormatNumber(string value)
        {
            System.Globalization.NumberFormatInfo numFormat = new System.Globalization.NumberFormatInfo();
            numFormat.NumberGroupSeparator = ",";
            numFormat.NumberDecimalDigits = 0;
            numFormat.NumberNegativePattern = 0;

            return Convert.ToInt64(value).ToString("N", numFormat);
        }

        public static String FormatNumber_Dot(string value)
        {
            System.Globalization.NumberFormatInfo numFormat = new System.Globalization.NumberFormatInfo();
            numFormat.NumberGroupSeparator = ".";
            numFormat.NumberDecimalDigits = 0;
            numFormat.NumberNegativePattern = 0;

            return Convert.ToInt64(value).ToString("N", numFormat);
        }

        public static String FormatNumber(Int32 value)
        {
            System.Globalization.NumberFormatInfo numFormat = new System.Globalization.NumberFormatInfo();
            numFormat.NumberGroupSeparator = ",";
            numFormat.NumberDecimalDigits = 0;
            numFormat.NumberNegativePattern = 0;

            return value.ToString("N", numFormat);
        }

        public static String FormatNumber(Int64 value)
        {
            System.Globalization.NumberFormatInfo numFormat = new System.Globalization.NumberFormatInfo();
            numFormat.NumberGroupSeparator = ",";
            numFormat.NumberDecimalDigits = 0;
            numFormat.NumberNegativePattern = 0;

            return value.ToString("N", numFormat);
        }

        public static String FormatNumber(double value)
        {
            System.Globalization.NumberFormatInfo numFormat = new System.Globalization.NumberFormatInfo();
            numFormat.NumberGroupSeparator = ",";
            numFormat.NumberDecimalDigits = 0;
            numFormat.NumberNegativePattern = 0;

            return value.ToString("N", numFormat);
        }

        public static String FormatNumber(decimal value)
        {
            System.Globalization.NumberFormatInfo numFormat = new System.Globalization.NumberFormatInfo();
            numFormat.NumberGroupSeparator = ",";
            numFormat.NumberDecimalDigits = 0;
            numFormat.NumberNegativePattern = 0;

            return value.ToString("N", numFormat);
        }
        public static String FormatNumberDecimal2(decimal value)
        {
            System.Globalization.NumberFormatInfo numFormat = new System.Globalization.NumberFormatInfo();
            numFormat.NumberGroupSeparator = ",";
            numFormat.NumberDecimalDigits = 2;
            numFormat.NumberNegativePattern = 0;

            return value.ToString("N", numFormat);
        }


    }

    public class Season
    {
        public static int GetSeasonByDateTime(DateTime dt)
        {
            if (dt.Month >= 1 && dt.Month <= 3)
            {
                return 1;
            }
            else if (dt.Month >= 4 && dt.Month <= 6)
            {
                return 2;
            }
            else if (dt.Month >= 7 && dt.Month <= 9)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }

        public static DateTime GetFirstDayOfSeason(int year, int season)
        {
            if (season == 1)
            {
                return new DateTime(year, 1, 1);
            }
            else if (season == 2)
            {
                return new DateTime(year, 4, 1);
            }
            else if (season == 3)
            {
                return new DateTime(year, 7, 1);
            }
            else
            {
                return new DateTime(year, 10, 1);
            }
        }

        public static DateTime GetLastDayOfSeason(int year, int season)
        {
            if (season == 1)
            {
                return new DateTime(year, 3, 31);
            }
            else if (season == 2)
            {
                return new DateTime(year, 6, 30);
            }
            else if (season == 3)
            {
                return new DateTime(year, 9, 30);
            }
            else
            {
                return new DateTime(year, 12, 31);
            }
        }

        public static DateTime GetFirstDayOfYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        public static DateTime GetFirstDayOfSeason(DateTime dt)
        {
            if (dt.Month >= 1 && dt.Month <= 3)
            {
                return new DateTime(dt.Year, 1, 1);
            }
            else if (dt.Month >= 4 && dt.Month <= 6)
            {
                return new DateTime(dt.Year, 4, 1);
            }
            else if (dt.Month >= 7 && dt.Month <= 9)
            {
                return new DateTime(dt.Year, 7, 1);
            }
            else
            {
                return new DateTime(dt.Year, 10, 1);
            }
        }

        public static DateTime GetLastDayOfSeason(DateTime dt)
        {
            if (dt.Month >= 1 && dt.Month <= 3)
            {
                return new DateTime(dt.Year, 3, 31);
            }
            else if (dt.Month >= 4 && dt.Month <= 6)
            {
                return new DateTime(dt.Year, 6, 30);
            }
            else if (dt.Month >= 7 && dt.Month <= 9)
            {
                return new DateTime(dt.Year, 9, 30);
            }
            else
            {
                return new DateTime(dt.Year, 12, 31);
            }
        }

        public static DateTime GetFirstDayOfYear(DateTime dt)
        {
            return new DateTime(dt.Year, 1, 1);
        }

        public static DateTime GetFirstDayOfMonth(int month, int year)
        {
            return new DateTime(year, month, 1);
        }

        public static DateTime GetLastDayOfMonth(int month, int year)
        {
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                return new DateTime(year, month, 31);
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                return new DateTime(year, month, 30);
            }
            else if (month == 2)
            {
                if (CheckLeapYear(year))
                {
                    return new DateTime(year, month, 29);
                }
                else
                {
                    return new DateTime(year, month, 28);
                }
            }
            return Constant.DEFAULT_DATE;
        }

        public static DateTime GetFirstDayOfWeek(DateTime dt)
        {
            if (dt.DayOfWeek == DayOfWeek.Monday)
            {
                return dt;
            }
            else if (dt.DayOfWeek == DayOfWeek.Tuesday)
            {
                return dt.AddDays(-1);
            }
            else if (dt.DayOfWeek == DayOfWeek.Wednesday)
            {
                return dt.AddDays(-2);
            }
            else if (dt.DayOfWeek == DayOfWeek.Thursday)
            {
                return dt.AddDays(-3);
            }
            else if (dt.DayOfWeek == DayOfWeek.Friday)
            {
                return dt.AddDays(-4);
            }
            else if (dt.DayOfWeek == DayOfWeek.Saturday)
            {
                return dt.AddDays(-5);
            }
            else if (dt.DayOfWeek == DayOfWeek.Sunday)
            {
                return dt.AddDays(-6);
            }
            else
            {
                return Constant.DEFAULT_DATE;
            }
        }

        public static DateTime GetLastDayOfWeek(DateTime dt)
        {
            if (dt.DayOfWeek == DayOfWeek.Monday)
            {
                return dt.AddDays(6);
            }
            else if (dt.DayOfWeek == DayOfWeek.Tuesday)
            {
                return dt.AddDays(5);
            }
            else if (dt.DayOfWeek == DayOfWeek.Wednesday)
            {
                return dt.AddDays(4);
            }
            else if (dt.DayOfWeek == DayOfWeek.Thursday)
            {
                return dt.AddDays(3);
            }
            else if (dt.DayOfWeek == DayOfWeek.Friday)
            {
                return dt.AddDays(2);
            }
            else if (dt.DayOfWeek == DayOfWeek.Saturday)
            {
                return dt.AddDays(1);
            }
            else if (dt.DayOfWeek == DayOfWeek.Sunday)
            {
                return dt;
            }
            else
            {
                return Constant.DEFAULT_DATE;
            }
        }

        private static bool CheckLeapYear(int year)
        {
            if (year % 4 != 0)
            {
                return false;
            }
            else
            {
                if (year % 100 != 0)
                {
                    return true;
                }
                else
                {
                    if (year % 400 == 0)
                    {
                        return true;
                    }
                    else return false;
                }
            }
        }
    };

    public class ConvertFilePattern
    {
        private string _path;
        private int _oldid;
        private int _newid;

        public ConvertFilePattern()
        {
            _path = "";
            _oldid = -1;
            _newid = -1;
        }

        public ConvertFilePattern(string path, int oldid, int newid)
        {
            _path = path;
            _oldid = oldid;
            _newid = newid;
        }
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        public int Oldid
        {
            get { return _oldid; }
            set { _oldid = value; }
        }
        public int Newid
        {
            get { return _newid; }
            set { _newid = value; }
        }
    }


    public static class Utils
    {
        public static DateTime ConvertLongToDate(long Ticks)
        {
            try
            {
                return new DateTime(Ticks);
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }
        }
        public static double GetGMTInMS()
        {
            var unixTime = DateTime.Now.ToUniversalTime() -
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return (double)unixTime.TotalMilliseconds;
        }
        public static bool IsValidEmail(string input)
        {
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            return regex.IsMatch(input);
        }

        public static bool IsValidDouble(string input)
        {
            Double temp;
            return Double.TryParse(input, out temp);
        }

        public static bool IsValidInt64(string input)
        {
            Int64 temp;
            return Int64.TryParse(input, out temp);
        }

        public static bool IsValidInt32(string input)
        {
            Int32 temp;
            return Int32.TryParse(input, out temp);
        }

        public static string ConvertToString(object value, string defaultValue)
        {
            try
            {
                return Convert.ToString(value.ToString().Trim());
            }
            catch
            {
                return defaultValue;
            }
        }

        public static int ConvertToInt32(object value, int defaultValue)
        {
            try
            {
                return Convert.ToInt32(value.ToString().Trim());
            }
            catch (Exception ex)
            {
                return defaultValue;
            }
        }

        public static double ConvertToIntDouble(object value, double defaultValue)
        {
            try
            {
                return Convert.ToDouble(value.ToString().Trim());
            }
            catch
            {
                return defaultValue;
            }
        }

        public static double? ConvertToNullAbleDouble(object value, double? defaultValue)
        {
            try
            {
                return Convert.ToDouble(value.ToString().Trim());
            }
            catch
            {
                return defaultValue;
            }
        }

        public static int? ConvertToNullableInt32(object value, int? defaultValue)
        {
            try
            {
                return Convert.ToInt32(value.ToString().Trim());
            }
            catch
            {
                return defaultValue;
            }
        }

        public static long ConvertToInt64(object value, long defaultValue)
        {
            try
            {
                return Convert.ToInt64(value.ToString().Trim());
            }
            catch
            {
                return defaultValue;
            }
        }

        public static long? ConvertToNullableInt64(object value, long? defaultValue)
        {
            try
            {
                return Convert.ToInt64(value.ToString().Trim());
            }
            catch
            {
                return defaultValue;
            }
        }

        public static bool ConvertToBoolean(object value, bool defaultValue)
        {
            try
            {
                return Convert.ToBoolean(value.ToString());
            }
            catch
            {
                return defaultValue;
            }
        }

        public static DateTime ConvertToDateTime(object value, DateTime defaultValue)
        {
            try
            {
                DateTime datetime = new DateTime();
                bool result = DateTime.TryParseExact(value.ToString(), "dd/MM/yyyy", null, DateTimeStyles.None, out datetime);
                if (!result)
                {
                    datetime = DateTime.Parse(value.ToString().Trim());
                }
                return datetime;
            }
            catch
            {
                return defaultValue;
            }
        }

        public static DateTime ConvertToDateTime_Hour(object value, DateTime defaultValue)
        {
            try
            {
                DateTime datetime = new DateTime();
                bool result = DateTime.TryParseExact(value.ToString(), "dd/MM/yyyy hh:mm:ss", null, DateTimeStyles.None, out datetime);
                if (!result)
                {
                    datetime = DateTime.Parse(value.ToString().Trim());
                }
                return datetime;
            }
            catch
            {
                return defaultValue;
            }
        }

        public static decimal ConvertToDecimal(object value, int defaultValue)
        {
            try
            {
                return Convert.ToDecimal(value.ToString().Trim());
            }
            catch
            {
                return defaultValue;
            }
        }

        public static decimal? ConvertToNullableDecimal(object value, int? defaultValue)
        {
            try
            {
                return Convert.ToDecimal(value.ToString().Trim());
            }
            catch
            {
                return defaultValue;
            }
        }

        public static decimal? ConvertToNullableDecimalFromInt(object value, int? defaultValue)
        {
            try
            {
                if (value != null && !string.IsNullOrEmpty(value.ToString()))
                {
                    if (value.ToString().Contains(".") || value.ToString().Contains(","))
                    {
                        return Convert.ToDecimal(value.ToString().Trim());
                    }
                    else
                    {
                        int PhanNguyen = 0;
                        int PhanThapPhan = 0;
                        int value_Int = ConvertToInt32(value, 0);
                        if (value_Int > 0 && value_Int <= 10)
                        {
                            return Convert.ToDecimal(value_Int + ".0");
                        }
                        else if (value_Int > 10 && value_Int <= 100)
                        {
                            PhanNguyen = value_Int / 10;
                            PhanThapPhan = value_Int % 10;
                            return Convert.ToDecimal(PhanNguyen + "." + PhanThapPhan);
                        }
                        else if (value_Int > 100 && value_Int <= 1000)
                        {
                            PhanNguyen = value_Int / 100;
                            PhanThapPhan = value_Int % 100;
                            return Convert.ToDecimal(PhanNguyen + "." + PhanThapPhan);
                        }
                        else if (value_Int > 1000 && value_Int <= 10000)
                        {
                            PhanNguyen = value_Int / 1000;
                            PhanThapPhan = value_Int % 1000;
                            return Convert.ToDecimal(PhanNguyen + "." + PhanThapPhan);
                        }
                        else
                        {
                            return defaultValue;
                        }
                    }
                }
                else
                {
                    return defaultValue;
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        public static decimal? ConvertToNullableDecimalFromIntForTongDiemThi(object value, int? defaultValue)
        {
            try
            {
                if (value != null && !string.IsNullOrEmpty(value.ToString()))
                {
                    if (value.ToString().Contains(".") || value.ToString().Contains(","))
                    {
                        return Convert.ToDecimal(value.ToString().Trim());
                    }
                    else
                    {
                        int PhanNguyen = 0;
                        int PhanThapPhan = 0;
                        int value_Int = ConvertToInt32(value, 0);
                        if (value_Int > 0 && value_Int < 100)
                        {
                            return Convert.ToDecimal(value_Int + ".00");
                        }
                        else if (value_Int > 100 && value_Int < 1000)
                        {
                            PhanNguyen = value_Int / 10;
                            PhanThapPhan = value_Int % 10;
                            string PhanThapPhanTemp = PhanThapPhan == 0 ? "00" : PhanThapPhan.ToString();
                            return Convert.ToDecimal(PhanNguyen + "." + PhanThapPhanTemp);
                        }
                        else if (value_Int > 1000 && value_Int < 10000)
                        {
                            PhanNguyen = value_Int / 100;
                            PhanThapPhan = value_Int % 100;
                            string PhanThapPhanTemp = PhanThapPhan == 0 ? "00" : PhanThapPhan.ToString();
                            return Convert.ToDecimal(PhanNguyen + "." + PhanThapPhanTemp);
                        }
                        else
                        {
                            return defaultValue;
                        }
                    }
                }
                else
                {
                    return defaultValue;
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        public static DateTime? ConvertToNullableDateTime(object value, DateTime? defaultValue)
        {
            try
            {
                DateTime datetime = new DateTime();
                bool result = DateTime.TryParseExact(value.ToString(), "dd/MM/yyyy", null, DateTimeStyles.None, out datetime);
                if (!result)
                {
                    datetime = DateTime.Parse(value.ToString().Trim());
                }
                return datetime;
            }
            catch
            {
                return defaultValue;
            }
        }

        public static DateTime? ConvertToNullableDateTimeFromInt(object value, DateTime? defaultValue)
        {
            try
            {
                if (value != null)
                {
                    if (value.ToString().Contains("/"))
                    {
                        DateTime datetime = new DateTime();
                        bool result = DateTime.TryParseExact(value.ToString(), "dd/MM/yyyy", null, DateTimeStyles.None, out datetime);
                        if (!result)
                        {
                            datetime = DateTime.Parse(value.ToString().Trim());
                        }
                        return datetime;
                    }
                    else
                    {
                        if (value.ToString().Length == 8)
                        {
                            int NgaySinh_Int = ConvertToInt32(value, 0);
                            if (NgaySinh_Int > 0)
                            {
                                int Nam = NgaySinh_Int % 10000;
                                int Thang = (NgaySinh_Int / 10000) % 100;
                                int Ngay = NgaySinh_Int / 1000000;
                                return new DateTime(Nam, Thang, Ngay);
                            }
                            else
                                return defaultValue;
                        }
                        else
                        {
                            return defaultValue;
                        }
                    }
                }
                else
                {
                    return defaultValue;
                }

            }
            catch
            {
                return defaultValue;
            }
        }

        public static string ConvertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        /// <summary>
        /// Bacth: Hash file content into string
        /// for example: 1e5e4212f86d8ecbe5acc956c97fa373
        /// </summary>
        /// <param name="file">file content - array of bytes</param>
        /// <returns>string with 32 characters of length</returns>
        public static string HashFile(byte[] file)
        {
            MD5 md5 = MD5.Create();
            StringBuilder sb = new StringBuilder();

            byte[] hashed = md5.ComputeHash(file);
            foreach (byte b in hashed)
                // convert to hexa
                sb.Append(b.ToString("x2").ToLower());

            // sb = set of hexa characters
            return sb.ToString();
        }

        /// <summary>
        /// Bacth: detemine path to store file
        /// for example: [1e]-[5e]-[42]-[1e5e4212f86d8ecbe5acc956c97fa373]
        /// </summary>
        /// <param name="file">file content - array of bytes</param>
        /// <returns>hashed path</returns>
        public static List<string> GetPath(byte[] file)
        {
            string hashed = HashFile(file);
            List<string> toReturn = new List<string>(3);
            toReturn.Add(hashed.Substring(0, 2));
            toReturn.Add(hashed.Substring(2, 2));
            toReturn.Add(hashed.Substring(4, 2));
            toReturn.Add(hashed);
            return toReturn; // for example: [1e]-[5e]-[42]-[1e5e4212f86d8ecbe5acc956c97fa373]
        }

        /// <summary>
        /// Gets the object., 
        /// </summary>
        /// <param name="dataReader">The data reader.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="valueIfNull">The value if null.</param>
        /// <returns></returns>
        public static object GetObject(object value, object valueIfNull)
        {
            if ((value != null) && (value != DBNull.Value))
            {
                return value;
            }
            return valueIfNull;
        }

        /// <summary>
        /// Gets the date time.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="valueIfNull">The value if null.</param>
        /// <returns></returns>
        public static DateTime GetDateTime(object value, DateTime valueIfNull)
        {
            value = GetObject(value, null);
            if (value == null)
            {
                return valueIfNull;
            }
            if (value is DateTime)
            {
                return (DateTime)value;
            }
            return DateTime.Parse(value.ToString());
        }

        public static Decimal GetDecimal(object value, Decimal valueIfNull)
        {
            value = GetObject(value, null);
            try
            {
                if (value == null)
                {
                    return valueIfNull;
                }
                if (value is Decimal)
                {
                    return (Decimal)value;
                }
                return Decimal.Parse(value.ToString());
            }
            catch
            {

                return valueIfNull;
            }

        }
        /// <summary>
        /// Gets the byte.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="valueIfNull">The value if null.</param>
        /// <returns></returns>
        public static byte GetByte(object value, byte valueIfNull)
        {
            value = GetObject(value, null);
            if (value == null)
            {
                return valueIfNull;
            }
            if (value is byte)
            {
                return (byte)value;
            }
            return byte.Parse(value.ToString());
        }
        /// <summary>
        /// Gets the boolean.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="valueIfNull">if set to <c>true</c> [value if null].</param>
        /// <returns></returns>
        public static bool GetBoolean(object value, bool valueIfNull)
        {
            value = GetObject(value, valueIfNull);
            if (value == null)
            {
                return valueIfNull;
            }
            if (value is bool)
            {
                return (bool)value;
            }
            if (!(value is byte))
            {
                return bool.Parse(value.ToString());
            }
            if (((byte)value) == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gets the string. 
        /// </summary>
        /// <param name="dataReader">The data reader.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="valueIfNull">The value if null.</param>
        /// <returns></returns>
        public static string GetString(object value, string valueIfNull)
        {
            value = GetObject(value, null);
            if (value == null)
            {
                return valueIfNull;
            }
            if (value is string)
            {
                return (string)value;
            }
            return value.ToString();
        }

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="valueIfNull">The value if null.</param>
        /// <returns></returns>
        public static float GetSingle(object value, float valueIfNull)
        {
            value = GetObject(value, null);
            if (value == null)
            {
                return valueIfNull;
            }
            if (value is float)
            {
                return (float)value;
            }
            return float.Parse(value.ToString());
        }

        public static float GetFloat(object value, long valueIfNull)
        {
            try
            {
                value = GetObject(value, null);
                if (value == null)
                {
                    return valueIfNull;
                }
                if (value is float)
                {
                    return (float)value;
                }
                if (String.IsNullOrEmpty(value.ToString()))
                    return 0;
                return float.Parse(value.ToString());
            }
            catch
            {
                return valueIfNull;
            }

        }
        /// <summary>
        /// Gets the int64.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="valueIfNull">The value if null.</param>
        /// <returns></returns>
        public static long GetInt64(object value, long valueIfNull)
        {
            value = GetObject(value, null);
            if (value == null)
            {
                return valueIfNull;
            }
            if (value is long)
            {
                return (long)value;
            }
            return long.Parse(value.ToString());
        }

        /// <summary>
        /// Gets the int32.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="valueIfNull">The value if null.</param>
        /// <returns></returns>
        public static int GetInt32(object value, int valueIfNull)
        {
            value = GetObject(value, null);
            if (value == null)
            {
                return valueIfNull;
            }
            if (value is int)
            {
                return (int)value;
            }
            return int.Parse(value.ToString());
        }

        public static double GetDouble(object value, double valueIfNull)
        {
            value = GetObject(value, null);
            if (value == null)
            {
                return valueIfNull;
            }
            if (value is double)
            {
                return (double)value;
            }
            return double.Parse(value.ToString());
        }

        //public static int GetidFromQueryString(string key, int valueIfNull)
        //{
        //    return Utils.ConvertToInt32(HttpContext.Current.Request.QueryString[key], valueIfNull);
        //}

        public static string GetExtension(string fileName)
        {
            int dotIndex = fileName.LastIndexOf(".");
            return dotIndex == -1 ? string.Empty : fileName.Substring(dotIndex + 1);
        }
        public static string GetFileNameWithoutExtention(string fileName)
        {
            int dotIndex = fileName.LastIndexOf(".");
            return dotIndex == -1 ? fileName : fileName.Substring(0, dotIndex);
        }


        //This code EnCode Base64
        private static string[] d2c = new string[] { "V", "_", "C", "M", "S" };

        private static int c2d(string c)
        {
            int d = 0;
            for (int i = 0, n = d2c.Length; i < n; ++i)
            {
                if (c == d2c[i])
                {
                    d = i;
                    break;
                }
            }
            return d;
        }

        public static int idFromString(string base64)
        {
            int pos = base64.Length / 2;
            int step = c2d(base64.Substring(pos, 1)) + d2c.Length;
            string orginal = String.Format("{0}{1}", base64.Substring(0, pos), base64.Substring(pos + 1));
            for (int i = 0; i < step; ++i)
            {
                orginal = DecodeFrom64(orginal);
            }
            return Convert.ToInt32(orginal);
        }

        public static string idToString(int id)
        {
            Random random = new Random();
            int step = random.Next(5, 10);
            string base64 = id.ToString();
            for (int i = 0; i < step; ++i)
            {
                base64 = EncodeTo64(base64);
            }
            int pos = base64.Length / 2;
            return String.Format("{0}{1}{2}", base64.Substring(0, pos), d2c[step - d2c.Length], base64.Substring(pos));
        }

        private static string DecodeFrom64(string encodedData)
        {

            byte[] encodedDataAsBytes = Convert.FromBase64String(encodedData);

            string returnValue = ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);

            return returnValue;

        }

        public static string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = ASCIIEncoding.ASCII.GetBytes(toEncode);

            string returnValue = Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;

        }
        public static string GetDateTime(DateTime datetime)
        {
            string pDate = String.Empty;
            if (datetime.Month < 10)
            {
                pDate = pDate + "0" + datetime.Month.ToString();
            }
            else
            {
                pDate = pDate + datetime.Month.ToString();
            }
            if (datetime.Day < 10)
            {
                pDate = pDate + "0" + datetime.Day.ToString();
            }
            else
            {
                pDate = pDate + datetime.Day.ToString();
            }
            string year = datetime.Year.ToString().Substring(2, 2);
            pDate = year + pDate;
            return pDate;
        }
        public static string GetMaPhieu(string pMa)
        {
            int pMaBerfor = 0;
            string pMaAfter = String.Empty;

            pMaBerfor = Utils.ConvertToInt32(pMa.Substring(pMa.Length - 6), 0) + 1;
            for (int i = 0; i < 6 - pMaBerfor.ToString().Length; i++)
            {
                pMaAfter = pMaAfter + "0";
            }
            return pMaAfter + pMaBerfor.ToString();
        }
        public static bool CheckSpecialCharacter(string Chuoi)
        {
            var val = Regex.IsMatch(Chuoi, @"[~`!@#$%^&*()-+=|\{}':;.<>/?]");
            if (val == true)
            {
                return false;
            }
            return true;
        }
        public static bool CheckPhoneNumber(string Value)
        {
            if (Regex.IsMatch(Value, @"^[0-9]*$"))
            {
                return false;
            }
            return true;

        }
        public static bool CheckCharacter(string Value)
        {
            if (Regex.IsMatch(Value, @"[A-Za-z]") || Regex.IsMatch(Value, @"[A-Za-zÀ-ȕ ]"))
            {
                return true;
            }
            return false;

        }
        public static bool CheckEmail(string Chuoi)
        {
            //if (Regex.IsMatch(Chuoi, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$") && Regex.IsMatch(Chuoi, @"\A[a-z0-9]+([-._][a-z0-9]+)*@([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,4}\z") && Regex.IsMatch(Chuoi, @"^(?=.{1,64}@.{4,64}$)(?=.{6,100}$).*"))
            if (Regex.IsMatch(Chuoi, @"([a-z]+[a-z0-9]*[_\.]?[a-z0-9]+)@(([a-z0-9]+\.)*[a-z0-9]{2,}\.)+[a-z]{2,}") || Regex.IsMatch(Chuoi, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$") && Regex.IsMatch(Chuoi, @"\A[a-z0-9]+([-._][a-z0-9]+)*@([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,4}\z") && Regex.IsMatch(Chuoi, @"^(?=.{1,64}@.{4,64}$)(?=.{6,100}$).*"))
            {
                return true;
            }
            return false;
        }
        public static string Serialize<T>(T dataToSerialize)
        {
            try
            {
                var stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stringwriter, dataToSerialize);
                return stringwriter.ToString();
            }
            catch
            {
                throw;
            }
        }
        public static T Deserialize<T>(string xmlText)
        {
            try
            {
                var stringReader = new System.IO.StringReader(xmlText);
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
            catch
            {
                throw;
            }
        }

        public static string NumberToText(double inputNumber)
        {
            bool suffix = false;
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            // -12345678.3445435 => "-12345678"
            string sNumber = inputNumber.ToString("#");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }


            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            //return result + (suffix ? " đồng chẵn" : "");
            return result;
        }

        public static string Space(int length, int total)
        {
            string Space = "";
            for (int i = 0; i < total - length; i++)
            {
                Space += " ";
            }
            return Space;
        }


        #region DataTable
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        #endregion
    }
}
