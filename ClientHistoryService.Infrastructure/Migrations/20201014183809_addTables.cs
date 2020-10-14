using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ClientHistoryService.Infrastructure.Migrations
{
    public partial class addTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "communication_category",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_communication_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "communication_type",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_communication_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "delivery_channel_group",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery_channel_group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "delivery_channel",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    group_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery_channel", x => x.id);
                    table.ForeignKey(
                        name: "FK_delivery_channel_delivery_channel_group_group_id",
                        column: x => x.group_id,
                        principalTable: "delivery_channel_group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "communication_history",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_id = table.Column<long>(nullable: false),
                    type_id = table.Column<long>(nullable: false),
                    dt_sent = table.Column<DateTime>(nullable: false),
                    dt_received = table.Column<DateTime>(nullable: true),
                    client_id = table.Column<long>(nullable: false),
                    delivery_channel_id = table.Column<long>(nullable: false),
                    route = table.Column<int>(nullable: false),
                    manager_id = table.Column<long>(nullable: true),
                    product = table.Column<string>(nullable: true),
                    message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_communication_history", x => x.id);
                    table.ForeignKey(
                        name: "FK_communication_history_communication_category_category_id",
                        column: x => x.category_id,
                        principalTable: "communication_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_communication_history_delivery_channel_delivery_channel_id",
                        column: x => x.delivery_channel_id,
                        principalTable: "delivery_channel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_communication_history_communication_type_type_id",
                        column: x => x.type_id,
                        principalTable: "communication_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_communication_history_category_id",
                table: "communication_history",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_communication_history_delivery_channel_id",
                table: "communication_history",
                column: "delivery_channel_id");

            migrationBuilder.CreateIndex(
                name: "IX_communication_history_type_id",
                table: "communication_history",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_delivery_channel_group_id",
                table: "delivery_channel",
                column: "group_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "communication_history");

            migrationBuilder.DropTable(
                name: "communication_category");

            migrationBuilder.DropTable(
                name: "delivery_channel");

            migrationBuilder.DropTable(
                name: "communication_type");

            migrationBuilder.DropTable(
                name: "delivery_channel_group");
        }
    }
}
