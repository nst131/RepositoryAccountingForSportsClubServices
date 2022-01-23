using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceAccountingDA.Migrations
{
    public partial class InitialMigration : Migration
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
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
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
                    TypeSexId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Deal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    ClubCardId = table.Column<int>(type: "int", nullable: false),
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
                table: "Responsible",
                columns: new[] { "Id", "Name", "SerName", "Telephone" },
                values: new object[,]
                {
                    { 1, "Safia", "Mirinina", "447861212" },
                    { 2, "Lera", "Shablovskai", "335141721" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfSex",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Man" },
                    { 2, "Woman" }
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "Id", "CreatedAt", "Name", "SerName", "Telephone", "TypeSexId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, "Alexander", "Nikylskiy", "296138957", 1, null },
                    { 2, null, "Vitaliy", "Romanovskiy", "297138090", 1, null },
                    { 3, null, "Maria", "Gavrilova", "297861344", 2, null }
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
                    { 3, 0, "Eight Lesson", 65f, 1 },
                    { 17, 0, "Four Lesson", 40f, 6 },
                    { 16, 0, "One Lesson", 12f, 6 },
                    { 1, 0, "One Lesson", 10f, 1 },
                    { 15, 0, "Eight Lesson", 65f, 5 },
                    { 14, 0, "Four Lesson", 35f, 5 },
                    { 13, 0, "One Lesson", 10f, 5 },
                    { 12, 0, "Eight Lesson", 55f, 4 },
                    { 11, 0, "Four Lesson", 30f, 4 },
                    { 2, 0, "Four Lesson", 35f, 1 },
                    { 10, 0, "One Lesson", 9f, 4 },
                    { 9, 0, "Eight Lesson", 55f, 3 },
                    { 8, 0, "Four Lesson", 30f, 3 },
                    { 7, 0, "One Lesson", 9f, 3 },
                    { 6, 0, "Eight Lesson", 65f, 2 },
                    { 5, 0, "Four Lesson", 35f, 2 },
                    { 4, 0, "One Lesson", 10f, 2 },
                    { 18, 0, "Eight Lesson", 75f, 6 }
                });

            migrationBuilder.InsertData(
                table: "Trainer",
                columns: new[] { "Id", "Name", "SerName", "ServiceId", "Telephone", "TypeSexId" },
                values: new object[,]
                {
                    { 3, "Nastya", "Nesterenko", 3, "331872093", 2 },
                    { 4, "Olga", "Bogdan", 4, "447826796", 2 },
                    { 2, "Vitaliy", "Zazyla", 2, "334571331", 1 },
                    { 5, "Alexey", "Kikta", 5, "201482090", 1 },
                    { 1, "Valeriy", "Petrenko", 1, "335671309", 1 },
                    { 6, "Ivan", "Mazyrin", 6, "295047029", 1 }
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
                name: "IX_ClientsToTrainings_TrainingsId",
                table: "ClientsToTrainings",
                column: "TrainingsId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientToSubscriptions_SubscriptionsId",
                table: "ClientToSubscriptions",
                column: "SubscriptionsId");

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
                name: "ClientsToTrainings");

            migrationBuilder.DropTable(
                name: "ClientToSubscriptions");

            migrationBuilder.DropTable(
                name: "Deal");

            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "ClubCard");

            migrationBuilder.DropTable(
                name: "Responsible");

            migrationBuilder.DropTable(
                name: "Subscription");

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
