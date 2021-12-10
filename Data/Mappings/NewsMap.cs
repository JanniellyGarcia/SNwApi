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
    public class NewsMap : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.ToTable("News");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Type)
                .IsRequired()
                .HasColumnName("Tipo");

            builder.Property(prop => prop.Date)
                .IsRequired()
                .HasColumnName("Data");

            builder.Property(prop => prop.Informations)
                .IsRequired()
                .HasColumnName("Informacoes");

            builder.Property(prop => prop.Category)
                .IsRequired()
                .HasColumnName("Categoria");

            builder.Property(prop => prop.Image)
                .HasColumnName("Imagem");

            builder.Property(prop => prop.TypeImage)
                .HasColumnName("TipoImage");

            builder.Property(prop => prop.Path)
                .HasColumnName("Caminho");



        }
    }
}
