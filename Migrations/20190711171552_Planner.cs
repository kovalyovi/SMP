using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class Planner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    InvocationID = table.Column<int>(nullable: false),
                    BenedictionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hymn",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SMPID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hymn", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hymn_SMP_SMPID",
                        column: x => x.SMPID,
                        principalTable: "SMP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    SMPID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Member_SMP_SMPID",
                        column: x => x.SMPID,
                        principalTable: "SMP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ward_Member_FirstID",
                        column: x => x.FirstID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ward_Member_SecondID",
                        column: x => x.SecondID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hymn_SMPID",
                table: "Hymn",
                column: "SMPID");

            migrationBuilder.CreateIndex(
                name: "IX_Member_SMPID",
                table: "Member",
                column: "SMPID");

            migrationBuilder.CreateIndex(
                name: "IX_SMP_BenedictionID",
                table: "SMP",
                column: "BenedictionID");

            migrationBuilder.CreateIndex(
                name: "IX_SMP_ConductingID",
                table: "SMP",
                column: "ConductingID");

            migrationBuilder.CreateIndex(
                name: "IX_SMP_InvocationID",
                table: "SMP",
                column: "InvocationID");

            migrationBuilder.CreateIndex(
                name: "IX_SMP_PresidingID",
                table: "SMP",
                column: "PresidingID");

            migrationBuilder.CreateIndex(
                name: "IX_SMP_WardID",
                table: "SMP",
                column: "WardID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SMP_Member_BenedictionID",
                table: "SMP",
                column: "BenedictionID",
                principalTable: "Member",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SMP_Member_ConductingID",
                table: "SMP",
                column: "ConductingID",
                principalTable: "Member",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SMP_Member_InvocationID",
                table: "SMP",
                column: "InvocationID",
                principalTable: "Member",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SMP_Member_PresidingID",
                table: "SMP",
                column: "PresidingID",
                principalTable: "Member",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SMP_Ward_WardID",
                table: "SMP",
                column: "WardID",
                principalTable: "Ward",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_SMP_SMPID",
                table: "Member");

            migrationBuilder.DropTable(
                name: "Hymn");

            migrationBuilder.DropTable(
                name: "SMP");

            migrationBuilder.DropTable(
                name: "Ward");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
