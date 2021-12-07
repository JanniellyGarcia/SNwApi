using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class UserViewModel
    {
        [JsonPropertyName("Nome")]
        public string Name { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("Senha")]
        public string Senha { get; set; }

        [JsonPropertyName("Numero")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("DataNascimento")]
        public string BirthDate { get; set; }

        [JsonPropertyName("ChecarSenha")]
        public string PasswordCheck { get; set; }
    }
}
