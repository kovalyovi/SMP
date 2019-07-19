using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class updatedSpeakerTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speakers_Member_MemberID",
                table: "Speakers");

            migrationBuilder.RenameColumn(
                name: "MemberID",
                table: "Speakers",
                newName: "SpeakerID");

            migrationBuilder.RenameIndex(
                name: "IX_Speakers_MemberID",
                table: "Speakers",
                newName: "IX_Speakers_SpeakerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Speakers_Member_SpeakerID",
                table: "Speakers",
                column: "SpeakerID",
                principalTable: "Member",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speakers_Member_SpeakerID",
                table: "Speakers");

            migrationBuilder.RenameColumn(
                name: "SpeakerID",
                table: "Speakers",
                newName: "MemberID");

            migrationBuilder.RenameIndex(
                name: "IX_Speakers_SpeakerID",
                table: "Speakers",
                newName: "IX_Speakers_MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Speakers_Member_MemberID",
                table: "Speakers",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
