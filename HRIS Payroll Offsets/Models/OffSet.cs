using Newtonsoft.Json;
using System;

namespace HRIS_Payroll_Offsets.Models
{
    internal class OffSet
    {
        [JsonProperty(PropertyName = "Created_Moment")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "Position")]
        public string Position { get; set; }

        [JsonProperty(PropertyName = "Period")]
        public string Period { get; set; }

        [JsonProperty(PropertyName = "Payroll_Result")]
        public string Result { get; set; }

        [JsonProperty(PropertyName = "Earning")]
        public string Earing { get; set; }

        [JsonProperty(PropertyName = "Deduction")]
        public string Deduction { get; set; }

        [JsonProperty(PropertyName = "Result_Line_Amount")]
        public float Amount { get; set; }
    }
}
