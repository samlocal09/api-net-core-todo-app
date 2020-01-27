using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoListApp.Data.Common.Migrations
{
    public partial class AddNewColumnTaskSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusKey",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusKey",
                table: "Tasks");
        }
    }
}
