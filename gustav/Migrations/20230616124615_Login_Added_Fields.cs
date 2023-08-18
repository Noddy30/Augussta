using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gustav.Migrations
{
    /// <inheritdoc />
    public partial class Login_Added_Fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_logins",
                table: "logins");

            migrationBuilder.RenameTable(
                name: "logins",
                newName: "Logins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logins",
                table: "Logins",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Logins",
                table: "Logins");

            migrationBuilder.RenameTable(
                name: "Logins",
                newName: "logins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_logins",
                table: "logins",
                column: "Id");
        }
    }
}
