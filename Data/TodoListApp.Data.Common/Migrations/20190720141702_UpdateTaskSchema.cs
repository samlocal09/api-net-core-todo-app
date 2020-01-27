using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoListApp.Data.Common.Migrations
{
    public partial class UpdateTaskSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "EstimationTime",
                table: "Tasks",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "EstimationTime",
                table: "Tasks",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
