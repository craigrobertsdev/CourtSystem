using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourtSystem.Data
{
    /// <inheritdoc />
    public partial class MadeInformationNullableOnCaseFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseFileModel_InformationModel_InformationId",
                table: "CaseFileModel");

            migrationBuilder.AlterColumn<int>(
                name: "InformationId",
                table: "CaseFileModel",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseFileModel_InformationModel_InformationId",
                table: "CaseFileModel",
                column: "InformationId",
                principalTable: "InformationModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseFileModel_InformationModel_InformationId",
                table: "CaseFileModel");

            migrationBuilder.AlterColumn<int>(
                name: "InformationId",
                table: "CaseFileModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseFileModel_InformationModel_InformationId",
                table: "CaseFileModel",
                column: "InformationId",
                principalTable: "InformationModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
