﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Deslike : BaseEntity
    {
        public int PostId { get; set; }
        public Post PostagemId { get; set; }
        public int UserId { get; set; }
        public User UsuárioId { get; set; }
    }
}
