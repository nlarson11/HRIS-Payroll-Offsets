using HRIS_Payroll_Offsets.Communication;
using HRIS_Payroll_Offsets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRIS_Payroll_Offsets.Helper
{
    internal static class WDHelper
    {
        public static List<PeriodInfo> GetPeriods()
        {
            var wd = new Reports<ReportData<PeriodInfo>>();
            var lst = new List<PeriodInfo>();
            var sb = new StringBuilder();

            sb.Append("?End_Period!WID=");
            sb.Append(Settings.AppSettings.WidUSABIEnd);
            sb.Append("&Start_Period!WID=");
            sb.Append(Settings.AppSettings.WidUSABIStart);
            sb.Append("&format=json");

            var dt = new DateTime(2022, 5, 1);
            var res = wd.GetRptDataAsync(Settings.AppSettings.RptPeriod + sb.ToString()).Result.Rows.Where(r => r.StartDate >= dt).OrderBy(o => o.StartDate).ToList();
            lst.AddRange(res);

            //sb.Clear();
            //sb.Append("?End_Period!WID=");
            //sb.Append(Settings.AppSettings.WidCANBIEnd);
            //sb.Append("&Start_Period!WID=");
            //sb.Append(Settings.AppSettings.WidCANBIStart);
            //sb.Append("&format=json");

            //dt = new DateTime(2023, 4, 1);
            //res = wd.GetRptDataAsync(Settings.AppSettings.RptPeriod + sb.ToString()).Result.Rows.Where(r => r.StartDate >= dt).OrderBy(o => o.StartDate).ToList();
            //lst.AddRange(res);

            sb.Clear();
            sb.Append("?End_Period!WID=");
            sb.Append(Settings.AppSettings.WidUSAWEEnd);
            sb.Append("&Start_Period!WID=");
            sb.Append(Settings.AppSettings.WidUSAWEStart);
            sb.Append("&format=json");

            dt = new DateTime(2023, 8, 1);
            res = wd.GetRptDataAsync(Settings.AppSettings.RptPeriod + sb.ToString()).Result.Rows.Where(r => r.StartDate >= dt).OrderBy(o => o.StartDate).ToList();
            lst.AddRange(res);

            return lst;
        }

        public static List<Payroll> GetOffSets(string period)
        {
            var sb = new StringBuilder();
            var wd = new Reports<ReportData<Payroll>>();

            sb.Append("?Include_Only_On_Demand_Payments_Missing_Offset=1");
            sb.Append("&Period!WID=");
            sb.Append(period);
            sb.Append("&format=json");

            return wd.GetRptDataAsync(Settings.AppSettings.RptOffset + sb.ToString()).Result.Rows;
        }
    }
}
