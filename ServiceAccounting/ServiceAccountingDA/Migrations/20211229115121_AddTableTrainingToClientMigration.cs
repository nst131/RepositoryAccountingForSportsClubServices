using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceAccountingDA.Migrations
{
    public partial class AddTableTrainingToClientMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionToClient_Subscription_SubscriptionId",
                table: "SubscriptionToClient");

            migrationBuilder.DropTable(
                name: "ClientsToTrainings");

            migrationBuilder.CreateTable(
                name: "TrainingToClient",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingToClient", x => new { x.ClientId, x.TrainingId });
                    table.ForeignKey(
                        name: "FK_TrainingToClient_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingToClient_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingToClient_TrainingId",
                table: "TrainingToClient",
                column: "TrainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionToClient_Subscription_SubscriptionId",
                table: "SubscriptionToClient",
                column: "SubscriptionId",
                principalTable: "Subscription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionToClient_Subscription_SubscriptionId",
                table: "SubscriptionToClient");

            migrationBuilder.DropTable(
                name: "TrainingToClient");

            migrationBuilder.CreateTable(
                name: "ClientsToTrainings",
                columns: table => new
                {
                    ClientsId = table.Column<int>(type: "int", nullable: false),
                    TrainingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsToTrainings", x => new { x.ClientsId, x.TrainingsId });
                    table.ForeignKey(
                        name: "FK_ClientsToTrainings_Client_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientsToTrainings_Training_TrainingsId",
                        column: x => x.TrainingsId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientsToTrainings_TrainingsId",
                table: "ClientsToTrainings",
                column: "TrainingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionToClient_Subscription_SubscriptionId",
                table: "SubscriptionToClient",
                column: "SubscriptionId",
                principalTable: "Subscription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
