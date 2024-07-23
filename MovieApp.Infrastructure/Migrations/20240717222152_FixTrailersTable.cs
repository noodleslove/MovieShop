using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixTrailersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TrailerUrl",
                table: "Trailers",
                type: "nvarchar(2084)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Trailers",
                type: "nvarchar(2084)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(64)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TrailerUrl",
                table: "Trailers",
                type: "varchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2084)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Trailers",
                type: "varchar(64)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2084)");
        }
    }
}
