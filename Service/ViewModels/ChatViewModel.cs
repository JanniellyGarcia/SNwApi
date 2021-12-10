using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class ChatViewModel
    {
        [JsonPropertyName("IdDoReceptor")]
        public int IdReceptor { get; set; }

        [JsonPropertyName("IdUser1")]
        public UserViewModel IdUser1 { get; set; }

        [JsonPropertyName("IdDoEmissor")]
        public int IdEmissor { get; set; }

        [JsonPropertyName("IdUser1")]
        public UserViewModel IdUser2 { get; set; }

        //msg
        [JsonPropertyName("Mensagem")]
        public string mensagem { get; set; }
    }
}
