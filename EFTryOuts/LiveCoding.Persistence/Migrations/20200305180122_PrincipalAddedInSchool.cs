using Microsoft.EntityFrameworkCore.Migrations;

namespace LiveCoding.Persistence.Migrations
{
    public partial class PrincipalAddedInSchool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Principal",
                table: "Schools",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Principal",
                table: "Schools");
        }
    }
}
