using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourtSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourtLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InformationModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Information", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InformationEntry",
                columns: table => new
                {
                    InformationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Sequence = table.Column<int>(type: "INTEGER", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationEntry", x => new { x.InformationId, x.Id });
                    table.ForeignKey(
                        name: "FK_InformationEntry_Information_InformationId",
                        column: x => x.InformationId,
                        principalTable: "InformationModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseFile",
                columns: table => new
                {
                    CaseFileNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CourtFileNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    FactsOfCharge = table.Column<string>(type: "TEXT", nullable: false),
                    InformationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    DefendantId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseFile", x => x.CaseFileNumber);
                    table.ForeignKey(
                        name: "FK_CaseFile_Information_InformationId",
                        column: x => x.InformationId,
                        principalTable: "InformationModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseFileDocument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    CaseFileNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseFileDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseFileDocument_CaseFile_CaseFileNumber",
                        column: x => x.CaseFileNumber,
                        principalTable: "CaseFile",
                        principalColumn: "CaseFileNumber");
                });

            migrationBuilder.CreateTable(
                name: "CaseFileEnquiryLogModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntryText = table.Column<string>(type: "TEXT", nullable: false),
                    EnteredBy = table.Column<string>(type: "TEXT", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CaseFileNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseFileEnquiryLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseFileEnquiryLog_CaseFile_CaseFileNumber",
                        column: x => x.CaseFileNumber,
                        principalTable: "CaseFile",
                        principalColumn: "CaseFileNumber");
                });

            migrationBuilder.CreateTable(
                name: "ChargeModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sequence = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VictimName = table.Column<string>(type: "TEXT", nullable: true),
                    ChargeWording = table.Column<string>(type: "TEXT", nullable: false),
                    CaseFileNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Charge_CaseFile_CaseFileNumber",
                        column: x => x.CaseFileNumber,
                        principalTable: "CaseFile",
                        principalColumn: "CaseFileNumber");
                });

            migrationBuilder.CreateTable(
                name: "DefendantModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ListNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    ActiveCaseFileCaseFileNumber = table.Column<string>(type: "TEXT", nullable: true),
                    CourtListId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defendant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Defendant_CaseFile_ActiveCaseFileCaseFileNumber",
                        column: x => x.ActiveCaseFileCaseFileNumber,
                        principalTable: "CaseFile",
                        principalColumn: "CaseFileNumber");
                    table.ForeignKey(
                        name: "FK_Defendant_CourtLists_CourtListId",
                        column: x => x.CourtListId,
                        principalTable: "CourtLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HearingEntryModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HearingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AppearanceType = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    CaseFileNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HearingEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HearingEntry_CaseFile_CaseFileNumber",
                        column: x => x.CaseFileNumber,
                        principalTable: "CaseFile",
                        principalColumn: "CaseFileNumber");
                });

            migrationBuilder.CreateTable(
                name: "OccurrenceDocumentModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    CaseFileNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccurrenceDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OccurrenceDocument_CaseFile_CaseFileNumber",
                        column: x => x.CaseFileNumber,
                        principalTable: "CaseFile",
                        principalColumn: "CaseFileNumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseFile_DefendantId",
                table: "CaseFile",
                column: "DefendantId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseFile_InformationId",
                table: "CaseFile",
                column: "InformationId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseFileDocument_CaseFileNumber",
                table: "CaseFileDocument",
                column: "CaseFileNumber");

            migrationBuilder.CreateIndex(
                name: "IX_CaseFileEnquiryLog_CaseFileNumber",
                table: "CaseFileEnquiryLogModel",
                column: "CaseFileNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Charge_CaseFileNumber",
                table: "ChargeModel",
                column: "CaseFileNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Defendant_ActiveCaseFileCaseFileNumber",
                table: "DefendantModel",
                column: "ActiveCaseFileCaseFileNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Defendant_CourtListId",
                table: "DefendantModel",
                column: "CourtListId");

            migrationBuilder.CreateIndex(
                name: "IX_HearingEntry_CaseFileNumber",
                table: "HearingEntryModel",
                column: "CaseFileNumber");

            migrationBuilder.CreateIndex(
                name: "IX_OccurrenceDocument_CaseFileNumber",
                table: "OccurrenceDocumentModel",
                column: "CaseFileNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseFile_Defendant_DefendantId",
                table: "CaseFile",
                column: "DefendantId",
                principalTable: "DefendantModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseFile_Defendant_DefendantId",
                table: "CaseFile");

            migrationBuilder.DropTable(
                name: "CaseFileDocument");

            migrationBuilder.DropTable(
                name: "CaseFileEnquiryLogModel");

            migrationBuilder.DropTable(
                name: "ChargeModel");

            migrationBuilder.DropTable(
                name: "HearingEntryModel");

            migrationBuilder.DropTable(
                name: "InformationEntry");

            migrationBuilder.DropTable(
                name: "OccurrenceDocumentModel");

            migrationBuilder.DropTable(
                name: "DefendantModel");

            migrationBuilder.DropTable(
                name: "CaseFile");

            migrationBuilder.DropTable(
                name: "CourtLists");

            migrationBuilder.DropTable(
                name: "InformationModel");
        }
    }
}
