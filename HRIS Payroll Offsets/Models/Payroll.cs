using Newtonsoft.Json;
using System.Collections.Generic;

namespace HRIS_Payroll_Offsets.Models
{
    internal class Payroll
    {
        [JsonProperty(PropertyName = "Worker")]
        public string Worker {  get; set; }

        [JsonProperty(PropertyName = "Team_Member_ID")]
        public string Smid { get; set; }

        [JsonProperty(PropertyName = "Payroll_Result_Lines_group")]
        public List<OffSet> OffSets { get; set; }
    }
}
