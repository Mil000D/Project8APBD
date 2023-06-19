using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zadanie8.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserTableWithData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "IdUser", "Password", "RefreshToken", "RefreshTokenExpirationDate", "Username" },
                values: new object[,]
                {
                    { 1, "AQAAAAIAAYagAAAAEGt//1D17pzgvlD2/5e//PLfufwc3A5dPQC87gRa9sUzGEBay/vUaQEnr72MJHS34g==", null, null, "user8888" },
                    { 2, "AQAAAAIAAYagAAAAEC5EoGWRGZp3R+cuHSHxUekERQON1QN359LARvo3InUB2rEpBS6/ZJFS0zGfN7UPLA==", null, null, "user123" },
                    { 3, "AQAAAAIAAYagAAAAEIhIweGvZ3VjEC+w6qsAU/9tqUSZbW5klWoAOO64eBWbVi9R9jRjyLITxl+gx1K+ew==", null, null, "useruser2222" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
