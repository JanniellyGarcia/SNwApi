using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Chat : BaseEntity
    {
        public int ReceptorId { get; set; }
        public User User1Id { get; set; }
        public int EmissorId { get; set; }
        public User User2Id { get; set; }

        //msg
        public string mensagem { get; set; }
    }
}
