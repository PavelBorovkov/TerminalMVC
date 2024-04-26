using System.Text.Json.Serialization;

namespace TerminalMVC.Models
{
    public class TerminalResponseViewModel
    {
        [JsonPropertyName("terminal_id")]
        public int Terminal_id { get; set; }

        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("command_id")]
        public int Command_id { get; set; }

        [JsonPropertyName("parameter1")]
        public string? Parameter1 { get; set; }

        [JsonPropertyName("parameter2")]
        public string? Parameter2 { get; set; }

        [JsonPropertyName("parameter3")]
        public string? Parameter3 { get; set; }

        [JsonPropertyName("parameter4")]
        public string? Parameter4 { get; set; }

        [JsonPropertyName("parameter5")]
        public string? Parameter5 { get; set; }

        [JsonPropertyName("parameter6")]
        public string? Parameter6 { get; set; }

        [JsonPropertyName("parameter7")]
        public string? Parameter7 { get; set; }

        [JsonPropertyName("parameter8")]
        public string? Parameter8 { get; set; }


        [JsonPropertyName("str_parameter1")]
        public string? Str_parameter1 { get; set; }

        [JsonPropertyName("str_parameter2")]
        public string? Str_parameter2 { get; set; }

        [JsonPropertyName("state")]
        public int? State { get; set; }

        [JsonPropertyName("state_name")]
        public string? State_name { get; set; }

        [JsonPropertyName("time_created")]
        public DateTime Time_created { get; set; }

        [JsonPropertyName("time_delivered")]
        public DateTime? Time_delivered { get; set; }

        [JsonPropertyName("id")]
        public int? Id { get; set; }
    }
    public class TerminalResponse
    {
        [JsonPropertyName("item")]
        public TerminalResponseViewModel item { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
