using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_ContactType_ContactTypeId1",
                schema: "DirectoryContactInfo",
                table: "ContactInfo");

            migrationBuilder.DropIndex(
                name: "IX_ContactInfo_ContactTypeId1",
                schema: "DirectoryContactInfo",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "ContactTypeId1",
                schema: "DirectoryContactInfo",
                table: "ContactInfo");

            migrationBuilder.AlterColumn<long>(
                name: "ContactTypeId",
                schema: "DirectoryContactInfo",
                table: "ContactInfo",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_ContactTypeId",
                schema: "DirectoryContactInfo",
                table: "ContactInfo",
                column: "ContactTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_ContactType_ContactTypeId",
                schema: "DirectoryContactInfo",
                table: "ContactInfo",
                column: "ContactTypeId",
                principalSchema: "DirectoryContactType",
                principalTable: "ContactType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_ContactType_ContactTypeId",
                schema: "DirectoryContactInfo",
                table: "ContactInfo");

            migrationBuilder.DropIndex(
                name: "IX_ContactInfo_ContactTypeId",
                schema: "DirectoryContactInfo",
                table: "ContactInfo");

            migrationBuilder.AlterColumn<int>(
                name: "ContactTypeId",
                schema: "DirectoryContactInfo",
                table: "ContactInfo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ContactTypeId1",
                schema: "DirectoryContactInfo",
                table: "ContactInfo",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_ContactTypeId1",
                schema: "DirectoryContactInfo",
                table: "ContactInfo",
                column: "ContactTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_ContactType_ContactTypeId1",
                schema: "DirectoryContactInfo",
                table: "ContactInfo",
                column: "ContactTypeId1",
                principalSchema: "DirectoryContactType",
                principalTable: "ContactType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
