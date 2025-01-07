using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetrcDatabaseWriter.Migrations.MetrcAccess
{
    /// <inheritdoc />
    public partial class AddNullable_LabTestResult_CompoundNameCompoundType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReportUnit",
                table: "LabTestResult",
                type: "longchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longchar");

            migrationBuilder.AlterColumn<string>(
                name: "CompoundType",
                table: "LabTestResult",
                type: "longchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longchar");

            migrationBuilder.AlterColumn<string>(
                name: "CompoundName",
                table: "LabTestResult",
                type: "longchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longchar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReportUnit",
                table: "LabTestResult",
                type: "longchar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longchar",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompoundType",
                table: "LabTestResult",
                type: "longchar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longchar",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompoundName",
                table: "LabTestResult",
                type: "longchar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longchar",
                oldNullable: true);
        }
    }
}
