using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataApiService.Models
{
    public class CommandResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("parameter_name1")]
        public string Parameter_name1 { get; set; }

        [JsonPropertyName("parameter_name2")]
        public string Parameter_name2 { get; set; }

        [JsonPropertyName("parameter_name3")]
        public string Parameter_name3 { get; set; }

        [JsonPropertyName("parameter_value1")]
        public int Parameter_value1 { get; set; }

        [JsonPropertyName("parameter_value2")]
        public int Parameter_value2 { get; set; }

        [JsonPropertyName("parameter_value3")]
        public int Parameter_value3 { get; set; }
    }
}
