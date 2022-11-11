﻿// <auto-generated />
using System;
using MegansMatineeX.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MegansMatineeX.Migrations
{
    [DbContext(typeof(MegansMatineeXContext))]
    [Migration("20221111235143_DBRelations1")]
    partial class DBRelations1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DirectorMovie", b =>
                {
                    b.Property<int>("DirectorsID")
                        .HasColumnType("int");

                    b.Property<int>("MoviesMovieID")
                        .HasColumnType("int");

                    b.HasKey("DirectorsID", "MoviesMovieID");

                    b.HasIndex("MoviesMovieID");

                    b.ToTable("DirectorMovie");
                });

            modelBuilder.Entity("MegansMatineeX.Models.Director", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AdditionalInfo")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DirectorDetails")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirectorName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("ID");

                    b.ToTable("Director", (string)null);
                });

            modelBuilder.Entity("MegansMatineeX.Models.LeadAct", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AdditionalInfo")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LeadActDetails")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeadActName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("ID");

                    b.ToTable("LeadAct", (string)null);
                });

            modelBuilder.Entity("MegansMatineeX.Models.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .HasColumnType("int");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("LeadAct")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Review")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("WhereToWatch")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("MovieID");

                    b.ToTable("Movie", (string)null);
                });

            modelBuilder.Entity("MegansMatineeX.Models.MovieCast", b =>
                {
                    b.Property<int>("MovieCastID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieCastID"), 1L, 1);

                    b.Property<int?>("DirectorID")
                        .HasColumnType("int");

                    b.Property<int>("LeadActID")
                        .HasColumnType("int");

                    b.Property<int>("MovieID")
                        .HasColumnType("int");

                    b.Property<int?>("Rank")
                        .HasColumnType("int");

                    b.HasKey("MovieCastID");

                    b.HasIndex("DirectorID");

                    b.HasIndex("LeadActID");

                    b.HasIndex("MovieID");

                    b.ToTable("MovieCasts");
                });

            modelBuilder.Entity("DirectorMovie", b =>
                {
                    b.HasOne("MegansMatineeX.Models.Director", null)
                        .WithMany()
                        .HasForeignKey("DirectorsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MegansMatineeX.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesMovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MegansMatineeX.Models.MovieCast", b =>
                {
                    b.HasOne("MegansMatineeX.Models.Director", null)
                        .WithMany("MovieCasts")
                        .HasForeignKey("DirectorID");

                    b.HasOne("MegansMatineeX.Models.LeadAct", "LeadAct")
                        .WithMany("MovieCasts")
                        .HasForeignKey("LeadActID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MegansMatineeX.Models.Movie", "Movie")
                        .WithMany("MovieCasts")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LeadAct");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MegansMatineeX.Models.Director", b =>
                {
                    b.Navigation("MovieCasts");
                });

            modelBuilder.Entity("MegansMatineeX.Models.LeadAct", b =>
                {
                    b.Navigation("MovieCasts");
                });

            modelBuilder.Entity("MegansMatineeX.Models.Movie", b =>
                {
                    b.Navigation("MovieCasts");
                });
#pragma warning restore 612, 618
        }
    }
}
