using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zpo_projekt.Migrations
{
    /// <inheritdoc />
    public partial class CreateAlcoholsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alcohols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false, maxLength: 100),
                    Percentage = table.Column<double>(type: "REAL", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alcohols", x => x.Id);
                });

                migrationBuilder.CreateIndex(
                    name: "IX_Alcohols_Type",
                    table: "Alcohols",
                    column: "Type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alcohols");
        }
    }
}
