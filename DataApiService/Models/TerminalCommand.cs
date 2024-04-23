using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DataApiService.Models
{
    public class TerminalCommand
    {
        [JsonPropertyName("PageNumber")]
        public int PageNumber { get; set; }

        [JsonPropertyName("ItemsOnPage")]
        public int ItemsOnPage { get; set; }

        [JsonPropertyName("FilterText")]
        public string FilterText { get; set; }

        [JsonPropertyName("OrderByColumn")]
        public int OrderByColumn { get; set; }

        [JsonPropertyName("OrderDesc")]
        public bool OrderDesc { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; } = null!;


    }
}
