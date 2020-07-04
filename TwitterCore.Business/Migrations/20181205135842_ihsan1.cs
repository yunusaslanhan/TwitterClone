using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterCore.Business.Migrations
{
    public partial class ihsan1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_fromMessageUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_toMessageUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_fromMessageUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_toMessageUserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "fromMessageUserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "toMessageUserId",
                table: "Messages");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromId",
                table: "Messages",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ToId",
                table: "Messages",
                column: "ToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_FromId",
                table: "Messages",
                column: "FromId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ToId",
                table: "Messages",
                column: "ToId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_FromId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ToId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_FromId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ToId",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "fromMessageUserId",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "toMessageUserId",
                table: "Messages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_fromMessageUserId",
                table: "Messages",
                column: "fromMessageUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_toMessageUserId",
                table: "Messages",
                column: "toMessageUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_fromMessageUserId",
                table: "Messages",
                column: "fromMessageUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_toMessageUserId",
                table: "Messages",
                column: "toMessageUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
