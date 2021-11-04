using Microsoft.EntityFrameworkCore.Migrations;

namespace Minly.Data.Migrations
{
    public partial class RequestStarss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestStars_Stars_EventId",
                table: "RequestStars");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45f82841-d150-448a-be94-91dddeb82a79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d30a5de8-5ad0-43bf-b0e6-08fb6eadef45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5b30457-1a57-42af-8ecd-351fdd8c7646");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "RequestStars",
                newName: "StarId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestStars_EventId",
                table: "RequestStars",
                newName: "IX_RequestStars_StarId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "74c9e69c-57d4-42f6-a3d4-afe24c95a24e", "69d49d6b-4dac-4a74-b908-6bab1e41e38c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "67e725a3-d20d-48db-96aa-1a82cbffc4d9", "2de7e3f8-d6b8-415e-b3fe-0adbecc9eaa4", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d05b41e-710e-4b05-90b5-43c28b22ed49", "2a529517-5528-42dd-bb73-c691b0f6690c", "Star", "STAR" });

            migrationBuilder.AddForeignKey(
                name: "FK_RequestStars_Stars_StarId",
                table: "RequestStars",
                column: "StarId",
                principalTable: "Stars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestStars_Stars_StarId",
                table: "RequestStars");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67e725a3-d20d-48db-96aa-1a82cbffc4d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74c9e69c-57d4-42f6-a3d4-afe24c95a24e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d05b41e-710e-4b05-90b5-43c28b22ed49");

            migrationBuilder.RenameColumn(
                name: "StarId",
                table: "RequestStars",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestStars_StarId",
                table: "RequestStars",
                newName: "IX_RequestStars_EventId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d30a5de8-5ad0-43bf-b0e6-08fb6eadef45", "082fdb34-3456-419d-8c40-44809fb1ab78", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "45f82841-d150-448a-be94-91dddeb82a79", "b2bd459e-a570-4d3a-a1a3-439247a1f61b", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5b30457-1a57-42af-8ecd-351fdd8c7646", "b1295b4b-770c-4897-ac16-7dc1468e2d94", "Star", "STAR" });

            migrationBuilder.AddForeignKey(
                name: "FK_RequestStars_Stars_EventId",
                table: "RequestStars",
                column: "EventId",
                principalTable: "Stars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
