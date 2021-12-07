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
        public int IdPost { get; set; }
        [JsonPropertyName("Id_Post")]
        public PostViewModel IdPostagem { get; set; }

        [JsonPropertyName("IdentificadorUsuario")]
        public int IdUser { get; set; }
        [JsonPropertyName("Id_User")]
        public UserViewModel IdUsuário { get; set; }
    }
}
