using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceAccountingDA.Migrations
{
    public partial class AddTableSubscriptionToClientMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientToSubscriptions");

            migrationBuilder.CreateTable(
                name: "SubscriptionToClient",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionToClient", x => new { x.ClientId, x.SubscriptionId });
                    table.ForeignKey(
                        name: "FK_SubscriptionToClient_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionToClient_Subscription_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscriptionToClient");

            migrationBuilder.CreateTable(
                name: "ClientToSubscriptions",
                columns: table => new
                {
                    ClientsId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientToSubscriptions", x => new { x.ClientsId, x.SubscriptionsId });
                    table.ForeignKey(
                        name: "FK_ClientToSubscriptions_Client_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientToSubscriptions_Subscription_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientToSubscriptions_SubscriptionsId",
                table: "ClientToSubscriptions",
                column: "SubscriptionsId");
        }
    }
}
