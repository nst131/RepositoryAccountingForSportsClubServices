using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceAccountingDA.Migrations
{
    public partial class AddFieldEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Trainer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Responsible",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "alexander@mail.ru");

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "vitaliy@mail.ru");

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "maria@mail.ru");

            migrationBuilder.UpdateData(
                table: "Responsible",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "Saf@mail.ru");

            migrationBuilder.UpdateData(
                table: "Responsible",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "Lerka@mail.ru");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "Valer@mail.ru");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "Vital@mail.ru");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "Nast@mail.ru");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Email",
                value: "Olya@mail.ru");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 5,
                column: "Email",
                value: "Alex@mail.ru");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 6,
                column: "Email",
                value: "Ivan@mail.ru");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Trainer");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Responsible");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Client");
        }
    }
}
