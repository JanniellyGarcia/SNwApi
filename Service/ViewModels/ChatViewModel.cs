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
        [JsonPropertyName("Receptor_Id")]
        public int ReceptorId { get; set; }

        [JsonPropertyName("User1_Id")]
        public UserViewModel User1Id { get; set; }

        [JsonPropertyName("Emissor_Id")]
        public int EmissorId { get; set; }

        [JsonPropertyName("User1Id")]
        public UserViewModel User2Id { get; set; }

        //msg
        [JsonPropertyName("Mensagem")]
        public string mensagem { get; set; }
    }
}
