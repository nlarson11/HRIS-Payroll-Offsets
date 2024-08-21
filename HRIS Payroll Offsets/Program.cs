using HRIS_Payroll_Offsets.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRIS_Payroll_Offsets.Models;
using System.Text;

namespace HRIS_Payroll_Offsets
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Settings.AppSettings.Initialize();

            var lst = WDHelper.GetPeriods();
            var pLst = new List<Payroll>();
            var fs = File.Create(@"c:\temp\offsets.csv");
            var group = "";
            var bt = ASCIIEncoding.UTF8.GetBytes("Smid,Group,Period Start,Period End,Position,Amount\r\n");

            fs.Write(bt, 0, bt.Length); 

            lst.ForEach(r =>
            {
                Debug.WriteLine(r.ToString());

                var res = WDHelper.GetOffSets(r.WID);
                if (res == null || !res.Any()) return;

                Debug.WriteLine("Offsets Found:" + res.Count);

                res.ForEach(p =>
                {
                    if (r.Period.Contains("Canada"))
                        group = "CAN Bi-Weekly";
                    else if (r.Period.Contains("Bi-Weekly"))
                        group = "USA Bi-Weekly";
                    else
                        group = "USA Weekly";

                    p.OffSets.ForEach(o =>
                    {
                        var sb = new StringBuilder();
                        sb.Append(p.Smid).Append(",");
                        sb.Append(group).Append(",");
                        sb.Append(r.StartDate.ToString("yyyy-MM-dd")).Append(",");
                        sb.Append(r.EndDate.ToString("yyyy-MM-dd")).Append(",");
                        sb.Append(o.Position).Append(",");
                        sb.Append(o.Amount);
                        sb.Append("\r\n");

                        bt = ASCIIEncoding.UTF8.GetBytes(sb.ToString());
                        fs.Write(bt, 0, bt.Length);
                    });
                });
            });

            fs.Flush();
            fs.Close();
            fs.Dispose();
            fs = null;

            Debugger.Break();
        }
    }
}
