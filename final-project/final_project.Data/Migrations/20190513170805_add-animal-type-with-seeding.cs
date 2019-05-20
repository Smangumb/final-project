using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace final_project.Data.Migrations
{
    public partial class addanimaltypewithseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShelterTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ShelterTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Puppy" });

            migrationBuilder.InsertData(
                table: "ShelterTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Adult" });

            migrationBuilder.InsertData(
                table: "ShelterTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 3, "Senior" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShelterTypes");
        }
    }
}
