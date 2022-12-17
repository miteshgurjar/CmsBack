using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerManagmentSysytem.Migrations
{
    public partial class TWwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "analytical",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(nullable: true),
                    dateOfUpload = table.Column<DateTime>(nullable: false),
                    Images = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analytical", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerFullName = table.Column<string>(nullable: false),
                    OwnerEmail = table.Column<string>(nullable: false),
                    OwnerPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceName = table.Column<string>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.ServiceId);
                    table.UniqueConstraint("AK_ServiceTypes_ServiceName", x => x.ServiceName);
                    table.ForeignKey(
                        name: "FK_ServiceTypes_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Service",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Service_ServiceTypes_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServiceTypes",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectSpaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Level = table.Column<int>(nullable: false),
                    Stage = table.Column<string>(nullable: true),
                    BackendType = table.Column<string>(nullable: false),
                    FrontendType = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    typeOfUsage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectSpaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    token = table.Column<byte[]>(nullable: true),
                    CustomerFullName = table.Column<string>(maxLength: 2147483647, nullable: false),
                    CustomerEmail = table.Column<string>(nullable: false),
                    CustomerPassword = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false),
                    TypeOfCustomer = table.Column<string>(nullable: true),
                    FileData = table.Column<byte[]>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    TimeOfUpload = table.Column<DateTime>(nullable: false),
                    FileSize = table.Column<int>(nullable: false),
                    BaseImage64 = table.Column<string>(nullable: true),
                    projectSpaceId = table.Column<int>(nullable: true),
                    projectSpaceId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_projectSpaces_projectSpaceId",
                        column: x => x.projectSpaceId,
                        principalTable: "projectSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_projectSpaces_projectSpaceId1",
                        column: x => x.projectSpaceId1,
                        principalTable: "projectSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Service_CustomerId",
                table: "Customer_Service",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Service_ServiceId",
                table: "Customer_Service",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_OwnerId",
                table: "Customers",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_projectSpaceId",
                table: "Customers",
                column: "projectSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_projectSpaceId1",
                table: "Customers",
                column: "projectSpaceId1");

            migrationBuilder.CreateIndex(
                name: "IX_projectSpaces_CustomerID",
                table: "projectSpaces",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypes_OwnerId",
                table: "ServiceTypes",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Service_Customers_CustomerId",
                table: "Customer_Service",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_projectSpaces_Customers_CustomerID",
                table: "projectSpaces",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projectSpaces_Customers_CustomerID",
                table: "projectSpaces");

            migrationBuilder.DropTable(
                name: "analytical");

            migrationBuilder.DropTable(
                name: "Customer_Service");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "projectSpaces");
        }
    }
}
