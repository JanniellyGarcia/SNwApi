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
    public class PostMap : IEntityTypeConfiguration<Post>
    {

        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(prop => prop.Id);

            builder.Ignore(prop => prop.LikesDoPost);
            builder.Ignore(prop => prop.DeslikesDoPost);
            builder.Ignore(prop => prop.CommentsDoPost);
                   

            

            builder.Property(prop => prop.Description)
                   .IsRequired()
                   .HasColumnName("Description");

            builder.Property(prop => prop.Image)
                   .HasColumnName("Images");

            builder.Property(prop => prop.Path)
                   .HasColumnName("Path");

            builder.Property(prop => prop.Type)
                   .HasColumnName("Type");
            




        }
    }
}
