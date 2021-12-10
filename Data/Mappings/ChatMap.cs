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
    public class ChatMap : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.ToTable("Chats");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.mensagem)
                    .HasColumnName("Mensagens")
                    .IsRequired()
                    .HasColumnType("VARCHAR(1000)");
        }
    }
}
