using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class News : BaseEntity
    {
        public string Type { get; set; }
        public string Date { get; set; }
        public string Informations { get; set; }
        public string Category { get; set; }

        //about image:
        public string Image { get; set; }
        public string TypeImage { get; set; }
        public string Path { get; set; }
    }
}
