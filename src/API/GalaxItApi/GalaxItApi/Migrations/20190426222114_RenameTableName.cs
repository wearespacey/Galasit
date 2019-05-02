using Microsoft.EntityFrameworkCore.Migrations;

namespace GalaxItApi.Migrations
{
    public partial class RenameTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Tables_TableId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Bubbles_BubbleID",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Seats_SeatId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tables",
                table: "Tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bubbles",
                table: "Bubbles");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Tables",
                newName: "Table");

            migrationBuilder.RenameTable(
                name: "Seats",
                newName: "Seat");

            migrationBuilder.RenameTable(
                name: "Bubbles",
                newName: "Bubble");

            migrationBuilder.RenameIndex(
                name: "IX_Users_SeatId",
                table: "User",
                newName: "IX_User_SeatId");

            migrationBuilder.RenameColumn(
                name: "BubbleID",
                table: "Table",
                newName: "BubbleId");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_BubbleID",
                table: "Table",
                newName: "IX_Table_BubbleId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_TableId",
                table: "Seat",
                newName: "IX_Seat_TableId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Bubble",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Table",
                table: "Table",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bubble",
                table: "Bubble",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Table_TableId",
                table: "Seat",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Bubble_BubbleId",
                table: "Table",
                column: "BubbleId",
                principalTable: "Bubble",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Seat_SeatId",
                table: "User",
                column: "SeatId",
                principalTable: "Seat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Table_TableId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_Bubble_BubbleId",
                table: "Table");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Seat_SeatId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Table",
                table: "Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bubble",
                table: "Bubble");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Table",
                newName: "Tables");

            migrationBuilder.RenameTable(
                name: "Seat",
                newName: "Seats");

            migrationBuilder.RenameTable(
                name: "Bubble",
                newName: "Bubbles");

            migrationBuilder.RenameIndex(
                name: "IX_User_SeatId",
                table: "Users",
                newName: "IX_Users_SeatId");

            migrationBuilder.RenameColumn(
                name: "BubbleId",
                table: "Tables",
                newName: "BubbleID");

            migrationBuilder.RenameIndex(
                name: "IX_Table_BubbleId",
                table: "Tables",
                newName: "IX_Tables_BubbleID");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_TableId",
                table: "Seats",
                newName: "IX_Seats_TableId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bubbles",
                newName: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tables",
                table: "Tables",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bubbles",
                table: "Bubbles",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Tables_TableId",
                table: "Seats",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Bubbles_BubbleID",
                table: "Tables",
                column: "BubbleID",
                principalTable: "Bubbles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Seats_SeatId",
                table: "Users",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
