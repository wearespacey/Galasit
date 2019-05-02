using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GalaxItApi.Migrations
{
    public partial class RemoveRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Table_TableId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_Bubble_BubbleId",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Seat");

            migrationBuilder.AlterColumn<string>(
                name: "BubbleId",
                table: "Table",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "TableId",
                table: "Seat",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Seat",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Seat",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Table_TableId",
                table: "Seat",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Bubble_BubbleId",
                table: "Table",
                column: "BubbleId",
                principalTable: "Bubble",
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

            migrationBuilder.AlterColumn<string>(
                name: "BubbleId",
                table: "Table",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TableId",
                table: "Seat",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Seat",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Seat",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Seat",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
