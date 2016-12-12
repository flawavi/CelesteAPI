﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Celeste.Data;

namespace CelesteAPI.Migrations
{
    [DbContext(typeof(CelesteContext))]
    [Migration("20161211234951_SeedDatabase")]
    partial class SeedDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Celeste.Models.CelesteHost", b =>
                {
                    b.Property<int>("CelesteHostID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Greeting");

                    b.Property<string>("ImageURL");

                    b.Property<int>("JourneyID");

                    b.Property<string>("Lesson");

                    b.Property<string>("Name");

                    b.HasKey("CelesteHostID");

                    b.ToTable("CelesteHost");
                });

            modelBuilder.Entity("Celeste.Models.Explorer", b =>
                {
                    b.Property<int>("ExplorerID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Username");

                    b.HasKey("ExplorerID");

                    b.ToTable("Explorer");
                });

            modelBuilder.Entity("Celeste.Models.ExplorerJourney", b =>
                {
                    b.Property<int>("ExplorerJourneyID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.Property<int>("ExplorerID");

                    b.Property<int>("JourneyID");

                    b.Property<int>("Score");

                    b.Property<bool>("isCompleted");

                    b.HasKey("ExplorerJourneyID");

                    b.HasIndex("ExplorerID");

                    b.HasIndex("JourneyID");

                    b.ToTable("ExplorerJourney");
                });

            modelBuilder.Entity("Celeste.Models.ExplorerResponse", b =>
                {
                    b.Property<int>("ExplorerResponseID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Correct");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.Property<int>("ExplorerID");

                    b.HasKey("ExplorerResponseID");

                    b.HasIndex("ExplorerID");

                    b.ToTable("ExplorerResponse");
                });

            modelBuilder.Entity("Celeste.Models.Journey", b =>
                {
                    b.Property<int>("JourneyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Destination");

                    b.Property<int?>("ExplorerID");

                    b.Property<string>("Name");

                    b.HasKey("JourneyID");

                    b.HasIndex("ExplorerID");

                    b.ToTable("Journey");
                });

            modelBuilder.Entity("Celeste.Models.Trivia", b =>
                {
                    b.Property<int>("TriviaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer");

                    b.Property<int>("JourneyID");

                    b.Property<int>("Point");

                    b.Property<string>("Question");

                    b.HasKey("TriviaID");

                    b.HasIndex("JourneyID");

                    b.ToTable("Trivia");
                });

            modelBuilder.Entity("Celeste.Models.ExplorerJourney", b =>
                {
                    b.HasOne("Celeste.Models.Explorer", "Explorer")
                        .WithMany()
                        .HasForeignKey("ExplorerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Celeste.Models.Journey", "Journey")
                        .WithMany()
                        .HasForeignKey("JourneyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Celeste.Models.ExplorerResponse", b =>
                {
                    b.HasOne("Celeste.Models.Explorer", "Explorer")
                        .WithMany("ExplorerResponses")
                        .HasForeignKey("ExplorerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Celeste.Models.Journey", b =>
                {
                    b.HasOne("Celeste.Models.Explorer")
                        .WithMany("Journies")
                        .HasForeignKey("ExplorerID");
                });

            modelBuilder.Entity("Celeste.Models.Trivia", b =>
                {
                    b.HasOne("Celeste.Models.Journey", "Journey")
                        .WithMany("TriviaList")
                        .HasForeignKey("JourneyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}