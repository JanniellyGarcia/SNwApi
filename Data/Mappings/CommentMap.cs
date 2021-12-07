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
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comentarios");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Description_Comment)
                .HasColumnName("Comentario")
                .HasColumnType("varchar(500)");
        }
    }
}
