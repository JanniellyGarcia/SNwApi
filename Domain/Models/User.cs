using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public string PasswordCheck { get; set; }

    }
}
