using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paradise.Migrations
{
    /// <inheritdoc />
    public partial class updatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DebtSettlement");

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MVA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasicInfoId = table.Column<int>(type: "int", nullable: true),
                    LeadTokenId = table.Column<int>(type: "int", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccidentInLastYear = table.Column<bool>(type: "bit", nullable: false),
                    DateOfAccident = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YourFault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MVA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MVA_BasicInfo_BasicInfoId",
                        column: x => x.BasicInfoId,
                        principalTable: "BasicInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MVA_LeadToken_LeadTokenId",
                        column: x => x.LeadTokenId,
                        principalTable: "LeadToken",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MVA_BasicInfoId",
                table: "MVA",
                column: "BasicInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_MVA_LeadTokenId",
                table: "MVA",
                column: "LeadTokenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "MVA");

            migrationBuilder.CreateTable(
                name: "DebtSettlement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasicInfoId = table.Column<int>(type: "int", nullable: true),
                    LeadTokenId = table.Column<int>(type: "int", nullable: true),
                    CreditCardAccountStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtOwed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasCheckingAccountInName = table.Column<bool>(type: "bit", nullable: true),
                    HasUnsecuredDebt = table.Column<bool>(type: "bit", nullable: true),
                    InDebtConsolidationProgram = table.Column<bool>(type: "bit", nullable: true),
                    MonthlyIncome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isBankrupt = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtSettlement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebtSettlement_BasicInfo_BasicInfoId",
                        column: x => x.BasicInfoId,
                        principalTable: "BasicInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DebtSettlement_LeadToken_LeadTokenId",
                        column: x => x.LeadTokenId,
                        principalTable: "LeadToken",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DebtSettlement_BasicInfoId",
                table: "DebtSettlement",
                column: "BasicInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtSettlement_LeadTokenId",
                table: "DebtSettlement",
                column: "LeadTokenId");
        }
    }
}
