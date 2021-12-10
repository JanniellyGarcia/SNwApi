using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class NewsViewModel
    {
        [JsonPropertyName("Tipo")]
        public string Type { get; set; }
        [JsonPropertyName("Data")]
        public string Date { get; set; }
        [JsonPropertyName("Informacoes")]
        public string Informations { get; set; }
        [JsonPropertyName("Categorias")]
        public string Category { get; set; }

        //about image:
        [JsonPropertyName("Imagem")]
        public string Image { get; set; }
        [JsonPropertyName("TipoDaImagem")]
        public string TypeImage { get; set; }
        [JsonPropertyName("Caminho")]
        public string Path { get; set; }
    }
}
