using Microsoft.EntityFrameworkCore.Migrations;

namespace Minly.Data.Migrations
{
    public partial class UpdateEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4872b3f-f0f4-4c8b-916d-95664ca3f937", "13e5cb9c-4943-415a-8aa1-89d2df58847b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2db7ad0c-cec1-478c-be10-84eb6da2b9ff", "1e01fb85-f443-47df-8f30-698ab211f7e1", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "75a65fd8-bcc5-4802-9796-85d2479ec6b5", "199c0b81-ac1a-44dc-9250-60eb991dbb99", "Star", "STAR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2db7ad0c-cec1-478c-be10-84eb6da2b9ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75a65fd8-bcc5-4802-9796-85d2479ec6b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4872b3f-f0f4-4c8b-916d-95664ca3f937");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Events");

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
    }
}
