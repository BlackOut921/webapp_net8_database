using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp_net8_database.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyDbModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyDbModels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MyDbModels",
                columns: new[] { "Id", "Name", "TimeStamp" },
                values: new object[] { -1, "921", new DateTime(2024, 8, 19, 10, 8, 20, 839, DateTimeKind.Local).AddTicks(7816) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyDbModels");
        }
    }
}
