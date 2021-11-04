using Microsoft.EntityFrameworkCore.Migrations;

namespace Minly.Data.Migrations
{
    public partial class UpdateVideoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventVideos_EventMemberships_EventTypeId",
                table: "EventVideos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e157aed-cb9f-41f1-ba57-90dd683e0578");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45b78674-9dee-4ea5-a2bd-0add8135c557");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9dfaadf1-1428-47b0-8b69-806eb87f729e");

            migrationBuilder.RenameColumn(
                name: "EventTypeId",
                table: "EventVideos",
                newName: "EventMembershipId");

            migrationBuilder.RenameIndex(
                name: "IX_EventVideos_EventTypeId",
                table: "EventVideos",
                newName: "IX_EventVideos_EventMembershipId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2728d23-3fdc-4298-9dee-cb3592db7b01", "537193c3-e8d7-4a9f-bff1-48d7a4870915", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7fde828a-71f3-484f-a08b-ee7cb7a40cf2", "52855021-5ade-419b-8a20-115b83d05e6c", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9116f3ed-71c9-42cc-a5d2-c74a4d95e655", "51325d14-3917-4c11-b998-743fa63d40a9", "Star", "STAR" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventVideos_EventMemberships_EventMembershipId",
                table: "EventVideos",
                column: "EventMembershipId",
                principalTable: "EventMemberships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventVideos_EventMemberships_EventMembershipId",
                table: "EventVideos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fde828a-71f3-484f-a08b-ee7cb7a40cf2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9116f3ed-71c9-42cc-a5d2-c74a4d95e655");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2728d23-3fdc-4298-9dee-cb3592db7b01");

            migrationBuilder.RenameColumn(
                name: "EventMembershipId",
                table: "EventVideos",
                newName: "EventTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_EventVideos_EventMembershipId",
                table: "EventVideos",
                newName: "IX_EventVideos_EventTypeId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "45b78674-9dee-4ea5-a2bd-0add8135c557", "617a24da-c749-4fba-8603-aedb8bc2ec08", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e157aed-cb9f-41f1-ba57-90dd683e0578", "d026ceea-ef70-435d-93bc-75d3406e19c5", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9dfaadf1-1428-47b0-8b69-806eb87f729e", "7d1efdb2-a9fe-406d-873e-94b1da4c5c5a", "Star", "STAR" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventVideos_EventMemberships_EventTypeId",
                table: "EventVideos",
                column: "EventTypeId",
                principalTable: "EventMemberships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
