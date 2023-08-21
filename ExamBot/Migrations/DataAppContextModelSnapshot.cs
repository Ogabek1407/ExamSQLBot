﻿// <auto-generated />
using System;
using ExamBot.Service.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Telegram.Bot.Types;

#nullable disable

namespace ExamBot.Migrations
{
    [DbContext(typeof(DataAppContext))]
    partial class DataAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("ExamAppBot")
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ExamBot.Domain.Entity.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<int>("role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("clients", "ExamAppBot");
                });

            modelBuilder.Entity("ExamBot.Domain.Entity.Exam", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Message>("ExamContent")
                        .IsRequired()
                        .HasColumnType("jsonb")
                        .HasColumnName("exam_content");

                    b.Property<int>("MaxBall")
                        .HasColumnType("integer")
                        .HasColumnName("max_ball");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_time");

                    b.HasKey("Id");

                    b.ToTable("exams", "ExamAppBot");
                });

            modelBuilder.Entity("ExamBot.Domain.Entity.ExamResult", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<long>("ExamId")
                        .HasColumnType("bigint")
                        .HasColumnName("exam_id");

                    b.Property<Message>("ExamQuestions")
                        .IsRequired()
                        .HasColumnType("jsonb")
                        .HasColumnName("exam_questions");

                    b.Property<int>("ball")
                        .HasColumnType("integer")
                        .HasColumnName("ball");

                    b.Property<long>("clientId")
                        .HasColumnType("bigint")
                        .HasColumnName("client_Id");

                    b.HasKey("Id");

                    b.HasIndex("clientId");

                    b.ToTable("exam_result", "ExamAppBot");
                });

            modelBuilder.Entity("ExamBot.Domain.Entity.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("ClientId")
                        .HasColumnType("bigint")
                        .HasColumnName("client_id");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<long>("TelegramChatId")
                        .HasColumnType("bigint")
                        .HasColumnName("telegram_chat_id");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("user", "ExamAppBot");
                });

            modelBuilder.Entity("ExamBot.Domain.Entity.Client", b =>
                {
                    b.HasOne("ExamBot.Domain.Entity.User", "User")
                        .WithOne("Client")
                        .HasForeignKey("ExamBot.Domain.Entity.Client", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExamBot.Domain.Entity.ExamResult", b =>
                {
                    b.HasOne("ExamBot.Domain.Entity.Exam", "Exam")
                        .WithMany("ExamResults")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamBot.Domain.Entity.Client", "client")
                        .WithMany("ExamResults")
                        .HasForeignKey("clientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("client");
                });

            modelBuilder.Entity("ExamBot.Domain.Entity.Client", b =>
                {
                    b.Navigation("ExamResults");
                });

            modelBuilder.Entity("ExamBot.Domain.Entity.Exam", b =>
                {
                    b.Navigation("ExamResults");
                });

            modelBuilder.Entity("ExamBot.Domain.Entity.User", b =>
                {
                    b.Navigation("Client");
                });
#pragma warning restore 612, 618
        }
    }
}
