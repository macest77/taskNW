using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarcinSCatFact.Model
{
    /// <summary>
    /// Model reprezentujący odpowiedź z endpointu https://catfact.ninja/fact
    /// </summary>
    internal class CatFact
    {
        [JsonPropertyName("fact")]
        public string Fact { get; set; }

        [JsonPropertyName("length")]
        public int Length { get; set; }

        public override string ToString() => $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | Length: {Length} | Fact: {Fact}";
    }
}
