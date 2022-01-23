﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceAccountingDA.Context;

namespace ServiceAccountingDA.Migrations
{
    [DbContext(typeof(ServiceAccountingContext))]
    [Migration("20220114171505_AddFieldEmail")]
    partial class AddFieldEmail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ServiceAccountingDA.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("SerName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeSexId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TypeSexId");

                    b.ToTable("Client");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "alexander@mail.ru",
                            Name = "Alexander",
                            SerName = "Nikylskiy",
                            Telephone = "29 613-89-57",
                            TypeSexId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "vitaliy@mail.ru",
                            Name = "Vitaliy",
                            SerName = "Romanovskiy",
                            Telephone = "29 713-80-90",
                            TypeSexId = 1
                        },
                        new
                        {
                            Id = 3,
                            Email = "maria@mail.ru",
                            Name = "Maria",
                            SerName = "Gavrilova",
                            Telephone = "29 786-13-44",
                            TypeSexId = 2
                        });
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.ClientCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("ClubCardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateActivation")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("DateExpiration")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.HasIndex("ClubCardId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ClientCard");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.ClubCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DurationInDays")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("ClubCard");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DurationInDays = 180,
                            Name = "BeFit",
                            Price = 400f,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 2,
                            DurationInDays = 180,
                            Name = "BeFlexibleInLife",
                            Price = 380f,
                            ServiceId = 4
                        },
                        new
                        {
                            Id = 3,
                            DurationInDays = 120,
                            Name = "PathOfTheFighter",
                            Price = 300f,
                            ServiceId = 6
                        });
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Deal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("ClubCardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("ResponsibleId")
                        .HasColumnType("int");

                    b.Property<int?>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ClubCardId");

                    b.HasIndex("ResponsibleId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Deal");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountFreePlace")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Place");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AmountFreePlace = 15,
                            Name = "Gym"
                        },
                        new
                        {
                            Id = 2,
                            AmountFreePlace = 15,
                            Name = "GymnasticHall"
                        },
                        new
                        {
                            Id = 3,
                            AmountFreePlace = 15,
                            Name = "HallWithTatami"
                        });
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Responsible", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("SerName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Responsible");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Saf@mail.ru",
                            Name = "Safia",
                            SerName = "Mirinina",
                            Telephone = "44 786-12-12"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Lerka@mail.ru",
                            Name = "Lera",
                            SerName = "Shablovskai",
                            Telephone = "33 514-17-21"
                        });
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DurationInMinutes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("Service");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DurationInMinutes = 60,
                            Name = "Crossfit",
                            PlaceId = 1,
                            Price = 10f
                        },
                        new
                        {
                            Id = 2,
                            DurationInMinutes = 60,
                            Name = "BodyBuilding",
                            PlaceId = 1,
                            Price = 10f
                        },
                        new
                        {
                            Id = 3,
                            DurationInMinutes = 60,
                            Name = "Yoga",
                            PlaceId = 2,
                            Price = 9f
                        },
                        new
                        {
                            Id = 4,
                            DurationInMinutes = 60,
                            Name = "Stretching",
                            PlaceId = 2,
                            Price = 9f
                        },
                        new
                        {
                            Id = 5,
                            DurationInMinutes = 60,
                            Name = "Karate",
                            PlaceId = 3,
                            Price = 10f
                        },
                        new
                        {
                            Id = 6,
                            DurationInMinutes = 60,
                            Name = "MMA",
                            PlaceId = 3,
                            Price = 12f
                        });
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountWorkouts")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("Subscription");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AmountWorkouts = 1,
                            Name = "One Lesson",
                            Price = 10f,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 2,
                            AmountWorkouts = 4,
                            Name = "Four Lesson",
                            Price = 35f,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 3,
                            AmountWorkouts = 8,
                            Name = "Eight Lesson",
                            Price = 65f,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 4,
                            AmountWorkouts = 1,
                            Name = "One Lesson",
                            Price = 10f,
                            ServiceId = 2
                        },
                        new
                        {
                            Id = 5,
                            AmountWorkouts = 4,
                            Name = "Four Lesson",
                            Price = 35f,
                            ServiceId = 2
                        },
                        new
                        {
                            Id = 6,
                            AmountWorkouts = 8,
                            Name = "Eight Lesson",
                            Price = 65f,
                            ServiceId = 2
                        },
                        new
                        {
                            Id = 7,
                            AmountWorkouts = 1,
                            Name = "One Lesson",
                            Price = 9f,
                            ServiceId = 3
                        },
                        new
                        {
                            Id = 8,
                            AmountWorkouts = 4,
                            Name = "Four Lesson",
                            Price = 30f,
                            ServiceId = 3
                        },
                        new
                        {
                            Id = 9,
                            AmountWorkouts = 8,
                            Name = "Eight Lesson",
                            Price = 55f,
                            ServiceId = 3
                        },
                        new
                        {
                            Id = 10,
                            AmountWorkouts = 1,
                            Name = "One Lesson",
                            Price = 9f,
                            ServiceId = 4
                        },
                        new
                        {
                            Id = 11,
                            AmountWorkouts = 4,
                            Name = "Four Lesson",
                            Price = 30f,
                            ServiceId = 4
                        },
                        new
                        {
                            Id = 12,
                            AmountWorkouts = 8,
                            Name = "Eight Lesson",
                            Price = 55f,
                            ServiceId = 4
                        },
                        new
                        {
                            Id = 13,
                            AmountWorkouts = 1,
                            Name = "One Lesson",
                            Price = 10f,
                            ServiceId = 5
                        },
                        new
                        {
                            Id = 14,
                            AmountWorkouts = 4,
                            Name = "Four Lesson",
                            Price = 35f,
                            ServiceId = 5
                        },
                        new
                        {
                            Id = 15,
                            AmountWorkouts = 8,
                            Name = "Eight Lesson",
                            Price = 65f,
                            ServiceId = 5
                        },
                        new
                        {
                            Id = 16,
                            AmountWorkouts = 1,
                            Name = "One Lesson",
                            Price = 12f,
                            ServiceId = 6
                        },
                        new
                        {
                            Id = 17,
                            AmountWorkouts = 4,
                            Name = "Four Lesson",
                            Price = 40f,
                            ServiceId = 6
                        },
                        new
                        {
                            Id = 18,
                            AmountWorkouts = 8,
                            Name = "Eight Lesson",
                            Price = 75f,
                            ServiceId = 6
                        });
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.SubscriptionToClient", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("ClientId", "SubscriptionId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("SubscriptionToClient");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("SerName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeSexId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.HasIndex("TypeSexId");

                    b.ToTable("Trainer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Valer@mail.ru",
                            Name = "Valeriy",
                            SerName = "Petrenko",
                            ServiceId = 1,
                            Telephone = "33 567-13-09",
                            TypeSexId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "Vital@mail.ru",
                            Name = "Vitaliy",
                            SerName = "Zazyla",
                            ServiceId = 2,
                            Telephone = "33 457-13-31",
                            TypeSexId = 1
                        },
                        new
                        {
                            Id = 3,
                            Email = "Nast@mail.ru",
                            Name = "Nastya",
                            SerName = "Nesterenko",
                            ServiceId = 3,
                            Telephone = "33 187-20-93",
                            TypeSexId = 2
                        },
                        new
                        {
                            Id = 4,
                            Email = "Olya@mail.ru",
                            Name = "Olga",
                            SerName = "Bogdan",
                            ServiceId = 4,
                            Telephone = "44 782-67-96",
                            TypeSexId = 2
                        },
                        new
                        {
                            Id = 5,
                            Email = "Alex@mail.ru",
                            Name = "Alexey",
                            SerName = "Kikta",
                            ServiceId = 5,
                            Telephone = "29 148-20-90",
                            TypeSexId = 1
                        },
                        new
                        {
                            Id = 6,
                            Email = "Ivan@mail.ru",
                            Name = "Ivan",
                            SerName = "Mazyrin",
                            ServiceId = 6,
                            Telephone = "29 504-70-29",
                            TypeSexId = 1
                        });
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FinishTraining")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("ServicesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTraining")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("TrainerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServicesId");

                    b.HasIndex("TrainerId");

                    b.ToTable("Training");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.TrainingToClient", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.HasKey("ClientId", "TrainingId");

                    b.HasIndex("TrainingId");

                    b.ToTable("TrainingToClient");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.TypeOfSex", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.ToTable("TypeOfSex");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Man"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Woman"
                        });
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Arrival")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Visit");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Client", b =>
                {
                    b.HasOne("ServiceAccountingDA.Models.TypeOfSex", "TypeSex")
                        .WithMany("Clients")
                        .HasForeignKey("TypeSexId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TypeSex");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.ClientCard", b =>
                {
                    b.HasOne("ServiceAccountingDA.Models.Client", "Client")
                        .WithOne("ClientCard")
                        .HasForeignKey("ServiceAccountingDA.Models.ClientCard", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceAccountingDA.Models.ClubCard", "ClubCard")
                        .WithMany("ClientCards")
                        .HasForeignKey("ClubCardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ServiceAccountingDA.Models.Service", "Service")
                        .WithMany("ClientCards")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("ClubCard");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.ClubCard", b =>
                {
                    b.HasOne("ServiceAccountingDA.Models.Service", "Service")
                        .WithMany("ClubCards")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Deal", b =>
                {
                    b.HasOne("ServiceAccountingDA.Models.Client", "Client")
                        .WithMany("Deals")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ServiceAccountingDA.Models.ClubCard", "ClubCard")
                        .WithMany("Deals")
                        .HasForeignKey("ClubCardId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ServiceAccountingDA.Models.Responsible", "Responsible")
                        .WithMany("Deals")
                        .HasForeignKey("ResponsibleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ServiceAccountingDA.Models.Subscription", "Subscription")
                        .WithMany("Deals")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Client");

                    b.Navigation("ClubCard");

                    b.Navigation("Responsible");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Service", b =>
                {
                    b.HasOne("ServiceAccountingDA.Models.Place", "Place")
                        .WithMany("Services")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Place");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Subscription", b =>
                {
                    b.HasOne("ServiceAccountingDA.Models.Service", "Service")
                        .WithMany("Subscriptions")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.SubscriptionToClient", b =>
                {
                    b.HasOne("ServiceAccountingDA.Models.Client", "Client")
                        .WithMany("Subscriptions")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceAccountingDA.Models.Subscription", "Subscription")
                        .WithMany("Clients")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Trainer", b =>
                {
                    b.HasOne("ServiceAccountingDA.Models.Service", "Service")
                        .WithMany("Trainers")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ServiceAccountingDA.Models.TypeOfSex", "TypeSex")
                        .WithMany("Trainers")
                        .HasForeignKey("TypeSexId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("TypeSex");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Training", b =>
                {
                    b.HasOne("ServiceAccountingDA.Models.Service", "Service")
                        .WithMany("Trainings")
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceAccountingDA.Models.Trainer", "Trainer")
                        .WithMany("Trainings")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.TrainingToClient", b =>
                {
                    b.HasOne("ServiceAccountingDA.Models.Client", "Client")
                        .WithMany("Trainings")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceAccountingDA.Models.Training", "Training")
                        .WithMany("Clients")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Visit", b =>
                {
                    b.HasOne("ServiceAccountingDA.Models.Client", "Client")
                        .WithMany("Visits")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ServiceAccountingDA.Models.Service", "Service")
                        .WithMany("Visits")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Client", b =>
                {
                    b.Navigation("ClientCard");

                    b.Navigation("Deals");

                    b.Navigation("Subscriptions");

                    b.Navigation("Trainings");

                    b.Navigation("Visits");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.ClubCard", b =>
                {
                    b.Navigation("ClientCards");

                    b.Navigation("Deals");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Place", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Responsible", b =>
                {
                    b.Navigation("Deals");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Service", b =>
                {
                    b.Navigation("ClientCards");

                    b.Navigation("ClubCards");

                    b.Navigation("Subscriptions");

                    b.Navigation("Trainers");

                    b.Navigation("Trainings");

                    b.Navigation("Visits");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Subscription", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Deals");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Trainer", b =>
                {
                    b.Navigation("Trainings");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.Training", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("ServiceAccountingDA.Models.TypeOfSex", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Trainers");
                });
#pragma warning restore 612, 618
        }
    }
}
