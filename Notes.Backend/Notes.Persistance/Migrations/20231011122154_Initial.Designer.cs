﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Notes.Persistence;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Notes.Persistence.Migrations
{
    [DbContext(typeof(NotesDbContext))]
    [Migration("20231011122154_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NoteTag", b =>
                {
                    b.Property<Guid>("NotesNoteId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagsTagId")
                        .HasColumnType("uuid");

                    b.HasKey("NotesNoteId", "TagsTagId");

                    b.HasIndex("TagsTagId");

                    b.ToTable("NoteTag");
                });

            modelBuilder.Entity("Notes.Domain.Note", b =>
                {
                    b.Property<Guid>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateEdit")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateNote")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Details")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("NoteId");

                    b.HasIndex("NoteId")
                        .IsUnique();

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Notes.Domain.Notice", b =>
                {
                    b.Property<Guid>("NoticeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateEdit")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("NoticeId");

                    b.ToTable("Notices");
                });

            modelBuilder.Entity("Notes.Domain.Tag", b =>
                {
                    b.Property<Guid>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("NoticeTag", b =>
                {
                    b.Property<Guid>("NoticesNoticeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagsTagId")
                        .HasColumnType("uuid");

                    b.HasKey("NoticesNoticeId", "TagsTagId");

                    b.HasIndex("TagsTagId");

                    b.ToTable("NoticeTag");
                });

            modelBuilder.Entity("NoteTag", b =>
                {
                    b.HasOne("Notes.Domain.Note", null)
                        .WithMany()
                        .HasForeignKey("NotesNoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Notes.Domain.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NoticeTag", b =>
                {
                    b.HasOne("Notes.Domain.Notice", null)
                        .WithMany()
                        .HasForeignKey("NoticesNoticeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Notes.Domain.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
