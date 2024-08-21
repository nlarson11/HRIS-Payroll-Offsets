using Newtonsoft.Json;
using System;

namespace HRIS_Payroll_Offsets.Models
{
    internal class PeriodInfo
    {
        [JsonProperty(PropertyName = "Period")]
        public string Period { get; set; }

        [JsonProperty(PropertyName = "Period_Start_Date")]
        public DateTime StartDate { get; set; }

        [JsonProperty(PropertyName = "Period_End_Date")]
        public DateTime EndDate { get; set; }

        [JsonProperty(PropertyName = "workdayID")]
        public string WID {  get; set; }


        public string ToString()
        {
            return Period + " " + StartDate.ToString("yyyy-MM-dd") + " " + EndDate.ToString("yyyy-MM-dd") + " " + WID;
        }
    }
}
