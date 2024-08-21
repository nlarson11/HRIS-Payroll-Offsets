using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS_Payroll_Offsets.Settings
{
    internal static class AppSettings
    {
        public static string UserId { get; private set; }
        public static string UserPw { get; private set; }
        public static string RptPeriod { get; private set; }
        public static string RptOffset { get; private set; }
        public static string WidCANBIStart { get; private set; }
        public static string WidCANBIEnd { get; private set; }
        public static string WidUSABIStart { get; private set; }
        public static string WidUSABIEnd { get; private set; }
        public static string WidUSAWEStart { get; private set; }
        public static string WidUSAWEEnd { get; private set; }

        public static void Initialize()
        {
            UserId = ConfigurationManager.AppSettings["user.id"];
            UserPw = ConfigurationManager.AppSettings["user.pw"];
            RptPeriod = ConfigurationManager.AppSettings["rpt.period"];
            RptOffset = ConfigurationManager.AppSettings["rpt.offset"];
            WidCANBIStart = ConfigurationManager.AppSettings["wid.can.bi.start"];
            WidCANBIEnd = ConfigurationManager.AppSettings["wid.can.bi.end"];
            WidUSABIStart = ConfigurationManager.AppSettings["wid.us.bi.start"];
            WidUSABIEnd = ConfigurationManager.AppSettings["wid.us.bi.end"];
            WidUSAWEStart = ConfigurationManager.AppSettings["wid.us.we.start"];
            WidUSAWEEnd = ConfigurationManager.AppSettings["wid.us.we.end"];
        }
    }
}
