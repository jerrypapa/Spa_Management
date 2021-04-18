using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Spa_Management.Operations
{
    public class phoneNumberNomalizer
    {
        static bool invalid = false;
        public static string phoneNum(string num)
        {
            num = num.Trim();
            num = Regex.Replace(num, @"\s+", "");
            if (Int64.TryParse(num.Substring(1, num.Trim().Length - 1), out long res))
            {
                if (num.Trim().Length > 7)
                {
                    switch (num[0])
                    {
                        case '0':
                            {
                                if (num.Length > 8)
                                {
                                    num = num.Substring(1, num.Length - 1);
                                    if (num.Length == 9)
                                    {
                                        return "+254" + num;
                                    }
                                }
                                break;
                            }
                        case '+':
                            {
                                if (num.Length == 13)
                                {
                                    return num;
                                }
                                else
                                {
                                    if (num.Length == 14)
                                    {
                                        num = num.Substring(5, num.Length - 5);
                                        return "+254" + num;
                                    }
                                }
                                break;
                            }
                        case '7':
                            {
                                if (num.Length == 9)
                                {
                                    return "+254" + num;
                                }
                                break;
                            }
                        case '2':
                            {
                                if (num.Length == 12)
                                {
                                    return "+" + num;
                                }
                                break;
                            }
                    }
                }
            }
            return null;
        }

        //public static bool IsValidEmail(string email)
        //{
        //    try
        //    {
        //        var addr = new System.Net.Mail.MailAddress(email);
        //        return addr.Address == email;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        public static bool IsValidEmail(string strIn)
        {
             invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid email format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        private static string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
    }
}
