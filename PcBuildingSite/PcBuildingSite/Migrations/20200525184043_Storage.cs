using Microsoft.EntityFrameworkCore.Migrations;

namespace PcBuildingSite.Migrations
{
    public partial class Storage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PcStorage",
                columns: table => new
                {
                    model = table.Column<string>(nullable: false),
                    ssdOrHdd = table.Column<string>(nullable: false),
                    memeorySize = table.Column<string>(nullable: false),
                    readSpeed = table.Column<string>(nullable: false),
                    writeSpeed = table.Column<string>(nullable: false),
                    price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PcStorage", x => x.model);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PcStorage");
        }
    }
}
