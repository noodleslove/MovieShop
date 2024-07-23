using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TmdbUrl = table.Column<string>(type: "varchar(256)", nullable: false),
                    ImdbUrl = table.Column<string>(type: "varchar(256)", nullable: false),
                    Title = table.Column<string>(type: "varchar(64)", nullable: false),
                    OverView = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tagline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Runtime = table.Column<int>(type: "int", nullable: false),
                    Budget = table.Column<int>(type: "int", nullable: false),
                    Revenue = table.Column<int>(type: "int", nullable: false),
                    BackdropUrl = table.Column<string>(type: "varchar(256)", nullable: false),
                    PosterUrl = table.Column<string>(type: "varchar(256)", nullable: false),
                    OriginalLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
