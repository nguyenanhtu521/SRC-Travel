using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRCTravel.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogCreatedTimestam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TicketCounters_TicketCounterID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "TicketCounterID",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TicketCounters_TicketCounterID",
                table: "AspNetUsers",
                column: "TicketCounterID",
                principalTable: "TicketCounters",
                principalColumn: "TicketCounterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TicketCounters_TicketCounterID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "TicketCounterID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TicketCounters_TicketCounterID",
                table: "AspNetUsers",
                column: "TicketCounterID",
                principalTable: "TicketCounters",
                principalColumn: "TicketCounterID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
