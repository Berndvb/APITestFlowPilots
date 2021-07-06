﻿// <auto-generated />
using System;
using APITest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APITest.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210706090126_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APITest.Domain.BaseStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Attack")
                        .HasColumnType("bigint");

                    b.Property<long>("Defense")
                        .HasColumnType("bigint");

                    b.Property<long>("Hp")
                        .HasColumnType("bigint");

                    b.Property<long>("SpAttack")
                        .HasColumnType("bigint");

                    b.Property<long>("SpDefense")
                        .HasColumnType("bigint");

                    b.Property<long>("Speed")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("AllBaseStats");
                });

            modelBuilder.Entity("APITest.Domain.Name", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Chinese")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("English")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("French")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Japanese")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Names");
                });

            modelBuilder.Entity("APITest.Domain.Pokémon", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("NameId")
                        .HasColumnType("int");

                    b.Property<string>("SpriteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatsId")
                        .HasColumnType("int");

                    b.Property<string>("ThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NameId");

                    b.HasIndex("StatsId");

                    b.ToTable("Pokémons");
                });

            modelBuilder.Entity("APITest.Domain.PokémonType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("PokémonId")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PokémonId");

                    b.ToTable("PokémonType");
                });

            modelBuilder.Entity("APITest.Domain.Pokémon", b =>
                {
                    b.HasOne("APITest.Domain.Name", "Name")
                        .WithMany()
                        .HasForeignKey("NameId");

                    b.HasOne("APITest.Domain.BaseStats", "Stats")
                        .WithMany()
                        .HasForeignKey("StatsId");

                    b.Navigation("Name");

                    b.Navigation("Stats");
                });

            modelBuilder.Entity("APITest.Domain.PokémonType", b =>
                {
                    b.HasOne("APITest.Domain.Pokémon", null)
                        .WithMany("Type")
                        .HasForeignKey("PokémonId");
                });

            modelBuilder.Entity("APITest.Domain.Pokémon", b =>
                {
                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}
