using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Deslike : BaseEntity
    {
        public int IdPost { get; set; }
        public Post IdPostagem { get; set; }
        public int IdUser { get; set; }
        public User IdUsuário { get; set; }
    }
}
