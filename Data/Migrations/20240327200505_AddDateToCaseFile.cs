using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourtSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddDateToCaseFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseFile_Defendant_DefendantId",
                table: "CaseFile");

            migrationBuilder.DropForeignKey(
                name: "FK_Defendant_CaseFile_ActiveCaseFileCaseFileNumber",
                table: "DefendantModel");

            migrationBuilder.DropIndex(
                name: "IX_Defendant_ActiveCaseFileCaseFileNumber",
                table: "DefendantModel");

            migrationBuilder.DropColumn(
                name: "ActiveCaseFileCaseFileNumber",
                table: "DefendantModel");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "CourtLists",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "DefendantId",
                table: "CaseFile",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseFile_Defendant_DefendantId",
                table: "CaseFile",
                column: "DefendantId",
                principalTable: "DefendantModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseFile_Defendant_DefendantId",
                table: "CaseFile");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "CourtLists");

            migrationBuilder.AddColumn<string>(
                name: "ActiveCaseFileCaseFileNumber",
                table: "DefendantModel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DefendantId",
                table: "CaseFile",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Defendant_ActiveCaseFileCaseFileNumber",
                table: "DefendantModel",
                column: "ActiveCaseFileCaseFileNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseFile_Defendant_DefendantId",
                table: "CaseFile",
                column: "DefendantId",
                principalTable: "DefendantModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Defendant_CaseFile_ActiveCaseFileCaseFileNumber",
                table: "DefendantModel",
                column: "ActiveCaseFileCaseFileNumber",
                principalTable: "CaseFile",
                principalColumn: "CaseFileNumber");
        }
    }
}
