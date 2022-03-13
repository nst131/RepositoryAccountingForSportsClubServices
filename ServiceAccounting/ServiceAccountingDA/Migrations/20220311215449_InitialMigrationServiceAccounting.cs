using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceAccountingDA.Migrations
{
    public partial class InitialMigrationServiceAccounting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AmountFreePlace = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Responsible",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SerName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsible", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfSex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfSex", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    DurationInMinutes = table.Column<int>(type: "int", nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SerName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeSexId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_TypeOfSex_TypeSexId",
                        column: x => x.TypeSexId,
                        principalTable: "TypeOfSex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClubCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    DurationInDays = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubCard_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AmountWorkouts = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SerName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeSexId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainer_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainer_TypeOfSex_TypeSexId",
                        column: x => x.TypeSexId,
                        principalTable: "TypeOfSex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Arrival = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visit_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visit_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateActivation = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    DateExpiration = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ClubCardId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCard_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientCard_ClubCard_ClubCardId",
                        column: x => x.ClubCardId,
                        principalTable: "ClubCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientCard_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: true),
                    ClubCardId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ResponsibleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deal_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deal_ClubCard_ClubCardId",
                        column: x => x.ClubCardId,
                        principalTable: "ClubCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deal_Responsible_ResponsibleId",
                        column: x => x.ResponsibleId,
                        principalTable: "Responsible",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deal_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                        name: "FK_SubscriptionToClient_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    StartTraining = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    FinishTraining = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_Service_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Training_Trainer_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Place",
                columns: new[] { "Id", "AmountFreePlace", "Name" },
                values: new object[,]
                {
                    { 1, 15, "Gym" },
                    { 2, 15, "GymnasticHall" },
                    { 3, 15, "HallWithTatami" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfSex",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Man" },
                    { 2, "Woman" },
                    { 3, "NoGender" }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "DurationInMinutes", "Name", "PlaceId", "Price" },
                values: new object[,]
                {
                    { 1, 60, "Crossfit", 1, 10f },
                    { 2, 60, "BodyBuilding", 1, 10f },
                    { 3, 60, "Yoga", 2, 9f },
                    { 4, 60, "Stretching", 2, 9f },
                    { 5, 60, "Karate", 3, 10f },
                    { 6, 60, "MMA", 3, 12f }
                });

            migrationBuilder.InsertData(
                table: "ClubCard",
                columns: new[] { "Id", "DurationInDays", "Name", "Price", "ServiceId" },
                values: new object[,]
                {
                    { 1, 180, "BeFit", 400f, 1 },
                    { 3, 120, "PathOfTheFighter", 300f, 6 },
                    { 2, 180, "BeFlexibleInLife", 380f, 4 }
                });

            migrationBuilder.InsertData(
                table: "Subscription",
                columns: new[] { "Id", "AmountWorkouts", "Name", "Price", "ServiceId" },
                values: new object[,]
                {
                    { 3, 8, "Crossfit Eight", 65f, 1 },
                    { 16, 1, "MMA One", 12f, 6 },
                    { 1, 1, "Crossfit One", 10f, 1 },
                    { 15, 8, "Karate Eight", 65f, 5 },
                    { 14, 4, "Karate Four", 35f, 5 },
                    { 13, 1, "Karate One", 10f, 5 },
                    { 12, 8, "Stretching Eight", 55f, 4 },
                    { 11, 4, "Stretching Four", 30f, 4 },
                    { 10, 1, "Stretching One", 9f, 4 },
                    { 17, 4, "MMA Four", 40f, 6 },
                    { 9, 8, "Yoga Eight", 55f, 3 },
                    { 8, 4, "Yoga Four", 30f, 3 },
                    { 7, 1, "Yoga One", 9f, 3 },
                    { 6, 8, "BodyBuilding Eight", 65f, 2 },
                    { 5, 4, "BodyBuilding Four", 35f, 2 },
                    { 4, 1, "BodyBuilding One", 10f, 2 },
                    { 2, 4, "Crossfit Four", 35f, 1 },
                    { 18, 8, "MMA Eight", 75f, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_TypeSexId",
                table: "Client",
                column: "TypeSexId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCard_ClientId",
                table: "ClientCard",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientCard_ClubCardId",
                table: "ClientCard",
                column: "ClubCardId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCard_ServiceId",
                table: "ClientCard",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubCard_ServiceId",
                table: "ClubCard",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Deal_ClientId",
                table: "Deal",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Deal_ClubCardId",
                table: "Deal",
                column: "ClubCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Deal_ResponsibleId",
                table: "Deal",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_Deal_SubscriptionId",
                table: "Deal",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_PlaceId",
                table: "Service",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_ServiceId",
                table: "Subscription",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionToClient_SubscriptionId",
                table: "SubscriptionToClient",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_ServiceId",
                table: "Trainer",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_TypeSexId",
                table: "Trainer",
                column: "TypeSexId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_ServicesId",
                table: "Training",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_TrainerId",
                table: "Training",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingToClient_TrainingId",
                table: "TrainingToClient",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_ClientId",
                table: "Visit",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_ServiceId",
                table: "Visit",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientCard");

            migrationBuilder.DropTable(
                name: "Deal");

            migrationBuilder.DropTable(
                name: "SubscriptionToClient");

            migrationBuilder.DropTable(
                name: "TrainingToClient");

            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropTable(
                name: "ClubCard");

            migrationBuilder.DropTable(
                name: "Responsible");

            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Trainer");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "TypeOfSex");

            migrationBuilder.DropTable(
                name: "Place");
        }
    }
}
