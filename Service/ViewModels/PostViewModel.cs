using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class PostViewModel
    {
        [JsonPropertyName("Descricao")]
        public string Description { get; set; }

        [JsonPropertyName("Curtidas")]
        public List<LikeViewModel> LikesDoPost { get; set; }

        [JsonPropertyName("Descurtidas")]
        public List<DeslikeViewModel> DeslikesDoPost { get; set; }

        [JsonPropertyName("Comentarios")]
        public List<CommentViewModel> CommentsDoPost { get; set; }

        //about image:
        [JsonPropertyName("Imagem")]
        public string Image { get; set; }

        [JsonPropertyName("Tipo")]
        public string Type { get; set; }

        [JsonPropertyName("Caminho")]
        public string Path { get; set; }
    }
}
