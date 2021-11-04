using Microsoft.EntityFrameworkCore.Migrations;

namespace Minly.Data.Migrations
{
    public partial class UpdateVideoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "EventVideos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c8a5dc10-33f1-4e41-9cf6-e7aa05e2b935", "785c0f10-f578-4775-a800-9365039ff74c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba8f2a53-0e69-4565-a47b-36f60d511c5e", "4d2d832f-952a-4758-8623-f54b56371d68", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28f5f160-6cbb-4019-88dc-c32f33cff490", "90538246-2332-4589-874b-1278091a5225", "Star", "STAR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28f5f160-6cbb-4019-88dc-c32f33cff490");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba8f2a53-0e69-4565-a47b-36f60d511c5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8a5dc10-33f1-4e41-9cf6-e7aa05e2b935");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "EventVideos");

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
        }
    }
}
