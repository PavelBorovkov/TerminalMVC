using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace TerminalMVC.Models
{
    public class CommandTypesViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }


        [JsonPropertyName("parameter_name1")]
        public string? Parameter_name1 { get; set; }

        [JsonPropertyName("parameter_name2")]
        public string? Parameter_name2 { get; set; }

        [JsonPropertyName("parameter_name3")]
        public string? Parameter_name3 { get; set; }

        [JsonPropertyName("parameter_name4")]
        public string? Parameter_name4 { get; set; }

        [JsonPropertyName("parameter_name5")]
        public string? Parameter_name5 { get; set; }

        [JsonPropertyName("parameter_name6")]
        public string? Parameter_name6 { get; set; }

        [JsonPropertyName("parameter_name7")]
        public string? Parameter_name7 { get; set; }

        [JsonPropertyName("parameter_name8")]
        public string? Parameter_name8 { get; set; }


        [JsonPropertyName("str_parameter_name1")]
        public string? Str_parameter_name1 { get; set; }

        [JsonPropertyName("str_parameter_name2")]
        public string? Str_parameter_name2 { get; set; }


        [JsonPropertyName("parameter_default_value1")]
        public int? Parameter_default_value1 { get; set; }

        [JsonPropertyName("parameter_default_value2")]
        public int? Parameter_default_value2 { get; set; }

        [JsonPropertyName("parameter_default_value3")]
        public int? Parameter_default_value3 { get; set; }

        [JsonPropertyName("parameter_default_value4")]
        public int? Parameter_default_value4 { get; set; }

        [JsonPropertyName("parameter_default_value5")]
        public int? Parameter_default_value5 { get; set; }

        [JsonPropertyName("parameter_default_value6")]
        public int? Parameter_default_value6 { get; set; }

        [JsonPropertyName("parameter_default_value7")]
        public int? Parameter_default_value7 { get; set; }

        [JsonPropertyName("parameter_default_value8")]
        public int? Parameter_default_value8 { get; set; }


        [JsonPropertyName("str_parameter_default_value1")]
        public string? Str_parameter_default_value1 { get; set; }

        [JsonPropertyName("str_parameter_default_value2")]
        public string? Str_parameter_default_value2 { get; set; }


        [JsonPropertyName("visible")]
        public bool Visible { get; set; }
    }

    public class ConcreteCommand
    {
        public Task<CommandTypesResponse> commandTypeResponse { get; set; }
        public int CommandId { get; set; }
    }

    public class CommandTypesResponse
    {
        [JsonPropertyName("page_number")]
        public int Page_number;

        [JsonPropertyName("items_per_page")]
        public int Items_per_page;

        [JsonPropertyName("items_count")]
        public int Items_count;

        [JsonPropertyName("items")]
        public List<CommandTypesViewModel> Items;

    }

    
}
