using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Country
{
    public sealed class Country :Entity
    {
        public long Idx { get; set; }
        [JsonPropertyName("CountryCode")]
        public string? CntryCode { get; set; }
        [JsonPropertyName("CountryNameE")]
        public string? CntryNameE { get; set; }
        [JsonPropertyName("CountryName")]
        public string? CntryName { get; set; }
        [JsonIgnore]
        public string? CntintNameE { get; set; }
        [JsonPropertyName("CCY")]
        public string? Monetary { get; set; }
        [JsonIgnore]
        public int? UseYN { get; set; }
        [JsonIgnore]
        public int? RegUserIdx { get; set; }
        [JsonIgnore]
        public DateTime? RegTime { get; set; }
        [JsonIgnore]
        public DateTime? UpTime { get; set; }
        [JsonIgnore]
        public int? UpUserIdx { get; set; }

    }
}
