using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceAccountingDA.Migrations
{
    public partial class ChangerKeyInTableSubscriptionToClientMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionToClient_Subscription_ClientId",
                table: "SubscriptionToClient");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionToClient_SubscriptionId",
                table: "SubscriptionToClient",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionToClient_Subscription_SubscriptionId",
                table: "SubscriptionToClient",
                column: "SubscriptionId",
                principalTable: "Subscription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionToClient_Subscription_SubscriptionId",
                table: "SubscriptionToClient");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionToClient_SubscriptionId",
                table: "SubscriptionToClient");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionToClient_Subscription_ClientId",
                table: "SubscriptionToClient",
                column: "ClientId",
                principalTable: "Subscription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
