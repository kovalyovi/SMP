using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hymn",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hymn", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ward",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BishopID = table.Column<int>(nullable: false),
                    FirstID = table.Column<int>(nullable: false),
                    SecondID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ward_Member_BishopID",
                        column: x => x.BishopID,
                        principalTable: "Member",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Ward_Member_FirstID",
                        column: x => x.FirstID,
                        principalTable: "Member",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Ward_Member_SecondID",
                        column: x => x.SecondID,
                        principalTable: "Member",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SMP",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WardID = table.Column<int>(nullable: false),
                    PresidingID = table.Column<int>(nullable: false),
                    ConductingID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    OpeningHymnID = table.Column<int>(nullable: false),
                    SacramentHymnID = table.Column<int>(nullable: false),
                    IntermediateHymnID = table.Column<int>(nullable: false),
                    ClosingHymnID = table.Column<int>(nullable: false),
                    InvocationID = table.Column<int>(nullable: false),
                    BenedictionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SMP_Member_BenedictionID",
                        column: x => x.BenedictionID,
                        principalTable: "Member",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SMP_Hymn_ClosingHymnID",
                        column: x => x.ClosingHymnID,
                        principalTable: "Hymn",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SMP_Member_ConductingID",
                        column: x => x.ConductingID,
                        principalTable: "Member",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SMP_Hymn_IntermediateHymnID",
                        column: x => x.IntermediateHymnID,
                        principalTable: "Hymn",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SMP_Member_InvocationID",
                        column: x => x.InvocationID,
                        principalTable: "Member",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SMP_Hymn_OpeningHymnID",
                        column: x => x.OpeningHymnID,
                        principalTable: "Hymn",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SMP_Member_PresidingID",
                        column: x => x.PresidingID,
                        principalTable: "Member",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SMP_Hymn_SacramentHymnID",
                        column: x => x.SacramentHymnID,
                        principalTable: "Hymn",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SMP_Ward_WardID",
                        column: x => x.WardID,
                        principalTable: "Ward",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberID = table.Column<int>(nullable: false),
                    Topic = table.Column<string>(nullable: true),
                    SMPID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Speakers_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Speakers_SMP_SMPID",
                        column: x => x.SMPID,
                        principalTable: "SMP",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SMP_BenedictionID",
                table: "SMP",
                column: "BenedictionID");

            migrationBuilder.CreateIndex(
                name: "IX_SMP_ClosingHymnID",
                table: "SMP",
                column: "ClosingHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_SMP_ConductingID",
                table: "SMP",
                column: "ConductingID");

            migrationBuilder.CreateIndex(
                name: "IX_SMP_IntermediateHymnID",
                table: "SMP",
                column: "IntermediateHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_SMP_InvocationID",
                table: "SMP",
                column: "InvocationID");

            migrationBuilder.CreateIndex(
                name: "IX_SMP_OpeningHymnID",
                table: "SMP",
                column: "OpeningHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_SMP_PresidingID",
                table: "SMP",
                column: "PresidingID");

            migrationBuilder.CreateIndex(
                name: "IX_SMP_SacramentHymnID",
                table: "SMP",
                column: "SacramentHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_SMP_WardID",
                table: "SMP",
                column: "WardID");

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_MemberID",
                table: "Speakers",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_SMPID",
                table: "Speakers",
                column: "SMPID");

            migrationBuilder.CreateIndex(
                name: "IX_Ward_BishopID",
                table: "Ward",
                column: "BishopID");

            migrationBuilder.CreateIndex(
                name: "IX_Ward_FirstID",
                table: "Ward",
                column: "FirstID");

            migrationBuilder.CreateIndex(
                name: "IX_Ward_SecondID",
                table: "Ward",
                column: "SecondID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.DropTable(
                name: "SMP");

            migrationBuilder.DropTable(
                name: "Hymn");

            migrationBuilder.DropTable(
                name: "Ward");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
