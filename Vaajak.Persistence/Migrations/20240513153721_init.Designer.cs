﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vaajak.Persistence.Contexts;

#nullable disable

namespace Vaajak.Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240513153721_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PackageVocab", b =>
                {
                    b.Property<Guid>("PackageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VocabsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PackageId", "VocabsId");

                    b.HasIndex("VocabsId");

                    b.ToTable("PackageVocab");
                });

            modelBuilder.Entity("Vaajak.Domain.Entities.Example", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Caseexample")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Exampletran")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TranslateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Voice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TranslateId");

                    b.ToTable("Examples");
                });

            modelBuilder.Entity("Vaajak.Domain.Entities.Package", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PackageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("Vaajak.Domain.Entities.Translate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Usage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VocabId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Vocabtran")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("VocabId");

                    b.ToTable("Translates");
                });

            modelBuilder.Entity("Vaajak.Domain.Entities.Vocab", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vocabulary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vocabs");
                });

            modelBuilder.Entity("PackageVocab", b =>
                {
                    b.HasOne("Vaajak.Domain.Entities.Package", null)
                        .WithMany()
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vaajak.Domain.Entities.Vocab", null)
                        .WithMany()
                        .HasForeignKey("VocabsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vaajak.Domain.Entities.Example", b =>
                {
                    b.HasOne("Vaajak.Domain.Entities.Translate", "Translate")
                        .WithMany()
                        .HasForeignKey("TranslateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Translate");
                });

            modelBuilder.Entity("Vaajak.Domain.Entities.Translate", b =>
                {
                    b.HasOne("Vaajak.Domain.Entities.Vocab", "Vocab")
                        .WithMany("Translations")
                        .HasForeignKey("VocabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vocab");
                });

            modelBuilder.Entity("Vaajak.Domain.Entities.Vocab", b =>
                {
                    b.Navigation("Translations");
                });
#pragma warning restore 612, 618
        }
    }
}
