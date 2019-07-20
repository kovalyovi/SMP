﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Migrations
{
    [DbContext(typeof(SacramentMeetingPlannerContext))]
    [Migration("20190718233325_updatedSpeakerTwo")]
    partial class updatedSpeakerTwo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Hymn", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Hymn");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("ID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.SMP", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BenedictionID");

                    b.Property<int>("ClosingHymnID");

                    b.Property<int>("ConductingID");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("IntermediateHymnID");

                    b.Property<int>("InvocationID");

                    b.Property<int>("OpeningHymnID");

                    b.Property<int>("PresidingID");

                    b.Property<int>("SacramentHymnID");

                    b.Property<int>("WardID");

                    b.HasKey("ID");

                    b.HasIndex("BenedictionID");

                    b.HasIndex("ClosingHymnID");

                    b.HasIndex("ConductingID");

                    b.HasIndex("IntermediateHymnID");

                    b.HasIndex("InvocationID");

                    b.HasIndex("OpeningHymnID");

                    b.HasIndex("PresidingID");

                    b.HasIndex("SacramentHymnID");

                    b.HasIndex("WardID");

                    b.ToTable("SMP");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Speakers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SMPID");

                    b.Property<int>("SpeakerID");

                    b.Property<string>("Topic");

                    b.HasKey("ID");

                    b.HasIndex("SMPID");

                    b.HasIndex("SpeakerID");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Ward", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BishopID");

                    b.Property<int>("FirstID");

                    b.Property<string>("Name");

                    b.Property<int>("SecondID");

                    b.HasKey("ID");

                    b.HasIndex("BishopID");

                    b.HasIndex("FirstID");

                    b.HasIndex("SecondID");

                    b.ToTable("Ward");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.SMP", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.Member", "Benediction")
                        .WithMany()
                        .HasForeignKey("BenedictionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SacramentMeetingPlanner.Models.Hymn", "ClosingHymn")
                        .WithMany()
                        .HasForeignKey("ClosingHymnID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SacramentMeetingPlanner.Models.Member", "Conducting")
                        .WithMany()
                        .HasForeignKey("ConductingID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SacramentMeetingPlanner.Models.Hymn", "IntermediateHymn")
                        .WithMany()
                        .HasForeignKey("IntermediateHymnID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SacramentMeetingPlanner.Models.Member", "Invocation")
                        .WithMany()
                        .HasForeignKey("InvocationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SacramentMeetingPlanner.Models.Hymn", "OpeningHymn")
                        .WithMany()
                        .HasForeignKey("OpeningHymnID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SacramentMeetingPlanner.Models.Member", "Presiding")
                        .WithMany()
                        .HasForeignKey("PresidingID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SacramentMeetingPlanner.Models.Hymn", "SacramentHymn")
                        .WithMany()
                        .HasForeignKey("SacramentHymnID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SacramentMeetingPlanner.Models.Ward", "Ward")
                        .WithMany()
                        .HasForeignKey("WardID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Speakers", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.SMP", "SMP")
                        .WithMany()
                        .HasForeignKey("SMPID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SacramentMeetingPlanner.Models.Member", "Speaker")
                        .WithMany()
                        .HasForeignKey("SpeakerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Ward", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.Member", "Bishop")
                        .WithMany()
                        .HasForeignKey("BishopID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SacramentMeetingPlanner.Models.Member", "First")
                        .WithMany()
                        .HasForeignKey("FirstID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SacramentMeetingPlanner.Models.Member", "Second")
                        .WithMany()
                        .HasForeignKey("SecondID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
