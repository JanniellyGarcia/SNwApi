using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class DeslikeViewModel
    {
        [JsonPropertyName("IdentificadorPostagem")]
        public int PostId { get; set; }
        [JsonPropertyName("PostId")]
        public PostViewModel IdPostagem { get; set; }

        [JsonPropertyName("IdentificadorUsuario")]
        public int UserId { get; set; }
        [JsonPropertyName("UserId")]
        public UserViewModel UsuárioId { get; set; }
    }
}
