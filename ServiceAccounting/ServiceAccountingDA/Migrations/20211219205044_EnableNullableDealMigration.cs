using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceAccountingDA.Migrations
{
    public partial class EnableNullableDealMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "Deal",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClubCardId",
                table: "Deal",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 1,
                column: "Telephone",
                value: "29 613-89-57");

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 2,
                column: "Telephone",
                value: "29 713-80-90");

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 3,
                column: "Telephone",
                value: "29 786-13-44");

            migrationBuilder.UpdateData(
                table: "Responsible",
                keyColumn: "Id",
                keyValue: 1,
                column: "Telephone",
                value: "44 786-12-12");

            migrationBuilder.UpdateData(
                table: "Responsible",
                keyColumn: "Id",
                keyValue: 2,
                column: "Telephone",
                value: "33 514-17-21");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Telephone",
                value: "33 567-13-09");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Telephone",
                value: "33 457-13-31");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Telephone",
                value: "33 187-20-93");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Telephone",
                value: "44 782-67-96");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 5,
                column: "Telephone",
                value: "29 148-20-90");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 6,
                column: "Telephone",
                value: "29 504-70-29");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "Deal",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClubCardId",
                table: "Deal",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 1,
                column: "Telephone",
                value: "296138957");

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 2,
                column: "Telephone",
                value: "297138090");

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 3,
                column: "Telephone",
                value: "297861344");

            migrationBuilder.UpdateData(
                table: "Responsible",
                keyColumn: "Id",
                keyValue: 1,
                column: "Telephone",
                value: "447861212");

            migrationBuilder.UpdateData(
                table: "Responsible",
                keyColumn: "Id",
                keyValue: 2,
                column: "Telephone",
                value: "335141721");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Telephone",
                value: "335671309");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Telephone",
                value: "334571331");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Telephone",
                value: "331872093");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Telephone",
                value: "447826796");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 5,
                column: "Telephone",
                value: "201482090");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 6,
                column: "Telephone",
                value: "295047029");
        }
    }
}
