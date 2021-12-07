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

                    b.Property<int>("IdPost")
                        .HasColumnType("int");

                    b.Property<int?>("IdPostagemId")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuárioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdPostagemId");

                    b.HasIndex("IdUsuárioId");

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

                    b.Property<int>("IdPost")
                        .HasColumnType("int");

                    b.Property<int?>("IdPostagemId")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuárioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdPostagemId");

                    b.HasIndex("IdUsuárioId");

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

                    b.Property<int>("IdPost")
                        .HasColumnType("int");

                    b.Property<int?>("IdPostagemId")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuárioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdPostagemId");

                    b.HasIndex("IdUsuárioId");

                    b.ToTable("Likes");
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

                    b.HasKey("Id");

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
                        .HasDefaultValue(new DateTime(2021, 12, 7, 13, 21, 32, 110, DateTimeKind.Local).AddTicks(5933))
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

            modelBuilder.Entity("Domain.Models.Comment", b =>
                {
                    b.HasOne("Domain.Models.Post", "IdPostagem")
                        .WithMany()
                        .HasForeignKey("IdPostagemId");

                    b.HasOne("Domain.Models.User", "IdUsuário")
                        .WithMany()
                        .HasForeignKey("IdUsuárioId");

                    b.Navigation("IdPostagem");

                    b.Navigation("IdUsuário");
                });

            modelBuilder.Entity("Domain.Models.Deslike", b =>
                {
                    b.HasOne("Domain.Models.Post", "IdPostagem")
                        .WithMany()
                        .HasForeignKey("IdPostagemId");

                    b.HasOne("Domain.Models.User", "IdUsuário")
                        .WithMany()
                        .HasForeignKey("IdUsuárioId");

                    b.Navigation("IdPostagem");

                    b.Navigation("IdUsuário");
                });

            modelBuilder.Entity("Domain.Models.Like", b =>
                {
                    b.HasOne("Domain.Models.Post", "IdPostagem")
                        .WithMany()
                        .HasForeignKey("IdPostagemId");

                    b.HasOne("Domain.Models.User", "IdUsuário")
                        .WithMany()
                        .HasForeignKey("IdUsuárioId");

                    b.Navigation("IdPostagem");

                    b.Navigation("IdUsuário");
                });
#pragma warning restore 612, 618
        }
    }
}