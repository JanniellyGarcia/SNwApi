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
        public User IdUser1{ get; set; }
        public int IdEmissor { get; set; }
        public User IdUser2 { get; set; }

        //msg
        public string mensagem { get; set; }
    }
}
