using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoTrackSeo.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchEngineCountTrends",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SearchDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    WordToSearch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchTool = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlToFind = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionList = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchEngineCountTrends", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchEngineCountTrends");
        }
    }
}
