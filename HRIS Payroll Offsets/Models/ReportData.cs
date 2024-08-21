using Newtonsoft.Json;
using System.Collections.Generic;

namespace HRIS_Payroll_Offsets.Models
{
    internal class ReportData<T>
    {
        [JsonProperty(PropertyName = "Report_Entry")]
        public List<T> Rows { get; set; }
    }
}
