using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STIVE_API.Migrations
{
    public partial class CreateTableEtatCommande : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantiteEnStock",
                table: "articles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantiteEnStock",
                table: "articles");
        }
    }
}
