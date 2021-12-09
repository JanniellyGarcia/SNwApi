using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Chat : BaseEntity
    {
        public int IdReceptor { get; set; }
        public int IdEmissor { get; set; }
        public string mensagem { get; set; }
    }
}
