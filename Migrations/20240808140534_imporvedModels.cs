using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paradise.Migrations
{
    /// <inheritdoc />
    public partial class imporvedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeadTokenId",
                table: "AutoInsurance",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AutoInsurance_LeadTokenId",
                table: "AutoInsurance",
                column: "LeadTokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoInsurance_LeadToken_LeadTokenId",
                table: "AutoInsurance",
                column: "LeadTokenId",
                principalTable: "LeadToken",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoInsurance_LeadToken_LeadTokenId",
                table: "AutoInsurance");

            migrationBuilder.DropIndex(
                name: "IX_AutoInsurance_LeadTokenId",
                table: "AutoInsurance");

            migrationBuilder.DropColumn(
                name: "LeadTokenId",
                table: "AutoInsurance");
        }
    }
}
