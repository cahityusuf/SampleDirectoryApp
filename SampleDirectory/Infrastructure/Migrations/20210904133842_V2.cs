using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_ContactType_ContactTypeId",
                schema: "DirectoryContactInfo",
                table: "ContactInfo");

            migrationBuilder.DropIndex(
                name: "IX_ContactInfo_ContactTypeId",
                schema: "DirectoryContactInfo",
                table: "ContactInfo");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "DirectoryContactType",
                table: "ContactType",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "DirectoryContactType",
                table: "ContactType",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
    }
}
