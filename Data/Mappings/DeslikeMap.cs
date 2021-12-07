using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class DeslikeMap : IEntityTypeConfiguration<Deslike>
    {
        public void Configure(EntityTypeBuilder<Deslike> builder)
        {
            builder.ToTable("Deslikes");

            builder.HasKey(prop => prop.Id);
        }
    }
}
