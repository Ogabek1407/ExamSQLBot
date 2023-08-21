using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Telegram.Bot.Types;

#nullable disable

namespace ExamBot.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ExamAppBot");

            migrationBuilder.CreateTable(
                name: "exams",
                schema: "ExamAppBot",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<int>(type: "integer", nullable: false),
                    start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    max_ball = table.Column<int>(type: "integer", nullable: false),
                    exam_content = table.Column<Message>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "ExamAppBot",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    client_id = table.Column<long>(type: "bigint", nullable: true),
                    login = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    telegram_chat_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                schema: "ExamAppBot",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                    table.ForeignKey(
                        name: "FK_clients_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "ExamAppBot",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exam_result",
                schema: "ExamAppBot",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    ball = table.Column<int>(type: "integer", nullable: false),
                    client_Id = table.Column<long>(type: "bigint", nullable: false),
                    exam_id = table.Column<long>(type: "bigint", nullable: false),
                    exam_questions = table.Column<Message>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exam_result", x => x.id);
                    table.ForeignKey(
                        name: "FK_exam_result_clients_client_Id",
                        column: x => x.client_Id,
                        principalSchema: "ExamAppBot",
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_exam_result_exams_id",
                        column: x => x.id,
                        principalSchema: "ExamAppBot",
                        principalTable: "exams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clients_user_id",
                schema: "ExamAppBot",
                table: "clients",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_exam_result_client_Id",
                schema: "ExamAppBot",
                table: "exam_result",
                column: "client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_user_login",
                schema: "ExamAppBot",
                table: "user",
                column: "login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exam_result",
                schema: "ExamAppBot");

            migrationBuilder.DropTable(
                name: "clients",
                schema: "ExamAppBot");

            migrationBuilder.DropTable(
                name: "exams",
                schema: "ExamAppBot");

            migrationBuilder.DropTable(
                name: "user",
                schema: "ExamAppBot");
        }
    }
}
