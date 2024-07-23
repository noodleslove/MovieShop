﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieApp.Infrastructure.Data;

#nullable disable

namespace MovieApp.Infrastructure.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    [Migration("20240717091153_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieApp.Core.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackdropUrl")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<string>("ImdbUrl")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("OriginalLanguage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OverView")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosterUrl")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Revenue")
                        .HasColumnType("int");

                    b.Property<int>("Runtime")
                        .HasColumnType("int");

                    b.Property<string>("Tagline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<string>("TmdbUrl")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}