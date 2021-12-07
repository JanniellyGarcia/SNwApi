using Data.Mappings;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }
        // Declara as entidades

        public DbSet<User> Users { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Deslike> Deslikes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        //Mapeia as entidades:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure); // Mapeamento de User
            modelBuilder.Entity<Like>(new LikeMap().Configure); // Mapeamento de like
            modelBuilder.Entity<Post>(new PostMap().Configure); // Mapeamento de post
            modelBuilder.Entity<Deslike>(new DeslikeMap().Configure); // Mapeamento de deslike
            modelBuilder.Entity<Comment>(new CommentMap().Configure); // Mapeamento de deslike
            

        }
    }
}
