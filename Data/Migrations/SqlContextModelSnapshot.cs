﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Create")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmissorId")
                        .HasColumnType("int");

                    b.Property<int>("ReceptorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update")
                        .HasColumnType("datetime2");

                    b.Property<int?>("User1IdId")
                        .HasColumnType("int");

                    b.Property<int?>("User2IdId")
                        .HasColumnType("int");

                    b.Property<string>("mensagem")
                        .IsRequired()
                        .HasColumnType("VARCHAR(1000)")
                        .HasColumnName("Mensagens");

                    b.HasKey("Id");

                    b.HasIndex("User1IdId");

                    b.HasIndex("User2IdId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Domain.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Create")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description_Comment")
                        .HasColumnType("varchar(500)")
                        .HasColumnName("Comentario");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("Domain.Models.Deslike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Create")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Deslikes");
                });

            modelBuilder.Entity("Domain.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Create")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Domain.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Categoria");

                    b.Property<DateTime>("Create")
                        .HasColumnType("datetime2");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Data");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Imagem");

                    b.Property<string>("Informations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Informacoes");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Caminho");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Tipo");

                    b.Property<string>("TypeImage")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TipoImage");

                    b.Property<DateTime>("Update")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("Domain.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Create")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Images");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Path");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Type");

                    b.Property<DateTime>("Update")
                        .HasColumnType("datetime2");

                    b.Property<int?>("userIdId")
                        .HasColumnType("int");

                    b.Property<int>("userIdPost")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userIdId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BirthDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Create")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 12, 16, 15, 18, 51, 447, DateTimeKind.Local).AddTicks(7995))
                        .HasColumnName("Create");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<string>("PasswordCheck")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Validação de senha");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Número de Telefone");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("senha");

                    b.Property<DateTime>("Update")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Models.Chat", b =>
                {
                    b.HasOne("Domain.Models.User", "User1Id")
                        .WithMany()
                        .HasForeignKey("User1IdId");

                    b.HasOne("Domain.Models.User", "User2Id")
                        .WithMany()
                        .HasForeignKey("User2IdId");

                    b.Navigation("User1Id");

                    b.Navigation("User2Id");
                });

            modelBuilder.Entity("Domain.Models.Comment", b =>
                {
                    b.HasOne("Domain.Models.Post", "PostagemId")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.User", "UsuárioId")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostagemId");

                    b.Navigation("UsuárioId");
                });

            modelBuilder.Entity("Domain.Models.Deslike", b =>
                {
                    b.HasOne("Domain.Models.Post", "PostagemId")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.User", "UsuárioId")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostagemId");

                    b.Navigation("UsuárioId");
                });

            modelBuilder.Entity("Domain.Models.Like", b =>
                {
                    b.HasOne("Domain.Models.Post", "Postagem")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.User", "IdUsuário")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdUsuário");

                    b.Navigation("Postagem");
                });

            modelBuilder.Entity("Domain.Models.Post", b =>
                {
                    b.HasOne("Domain.Models.User", "userId")
                        .WithMany()
                        .HasForeignKey("userIdId");

                    b.Navigation("userId");
                });
#pragma warning restore 612, 618
        }
    }
}
