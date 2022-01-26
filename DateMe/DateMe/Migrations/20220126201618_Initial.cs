using Microsoft.EntityFrameworkCore.Migrations;

namespace DateMe.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Age = table.Column<byte>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Major = table.Column<string>(nullable: true),
                    Stalker = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.ApplicationId);
                });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "ApplicationId", "Age", "FirstName", "LastName", "Major", "PhoneNumber", "Stalker" },
                values: new object[] { 1, (byte)32, "Michael", "Phelps", "Swimming", "123-456-7890", false });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "ApplicationId", "Age", "FirstName", "LastName", "Major", "PhoneNumber", "Stalker" },
                values: new object[] { 2, (byte)90, "Creed", "Bratton", null, "098-765-4321", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");
        }
    }
}
