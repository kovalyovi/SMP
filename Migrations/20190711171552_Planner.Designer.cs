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
    [Migration("20190711171552_Planner")]
    partial class Planner
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

                    b.Property<int?>("SMPID");

                    b.HasKey("ID");

                    b.HasIndex("SMPID");

                    b.ToTable("Hymn");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int?>("SMPID");

                    b.HasKey("ID");

                    b.HasIndex("SMPID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.SMP", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BenedictionID");

                    b.Property<int>("ConductingID");

                    b.Property<DateTime>("Date");

                    b.Property<int>("InvocationID");

                    b.Property<int>("PresidingID");

                    b.Property<int>("WardID");

                    b.HasKey("ID");

                    b.HasIndex("BenedictionID");

                    b.HasIndex("ConductingID");

                    b.HasIndex("InvocationID");

                    b.HasIndex("PresidingID");

                    b.HasIndex("WardID");

                    b.ToTable("SMP");
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

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Hymn", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.SMP")
                        .WithMany("Hymns")
                        .HasForeignKey("SMPID");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Member", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.SMP")
                        .WithMany("Speakers")
                        .HasForeignKey("SMPID");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.SMP", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.Member", "Benediction")
                        .WithMany()
                        .HasForeignKey("BenedictionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SacramentMeetingPlanner.Models.Member", "Conducting")
                        .WithMany()
                        .HasForeignKey("ConductingID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SacramentMeetingPlanner.Models.Member", "Invocation")
                        .WithMany()
                        .HasForeignKey("InvocationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SacramentMeetingPlanner.Models.Member", "Presiding")
                        .WithMany()
                        .HasForeignKey("PresidingID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SacramentMeetingPlanner.Models.Ward", "Ward")
                        .WithMany()
                        .HasForeignKey("WardID")
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