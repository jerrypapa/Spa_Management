using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Spa_Management.Migrations
{
    public partial class papa89 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

          
            migrationBuilder.CreateTable(
                name: "SpaCustomers_",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    IdNumber = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaCustomers_", x => x.Id);
                });
          
            migrationBuilder.CreateTable(
                name: "SpaServices_",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ServiceName = table.Column<string>(nullable: true),
                    SpaDetailsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaServices_", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpaServices__SpaDetails_SpaDetailsId",
                        column: x => x.SpaDetailsId,
                        principalTable: "SpaDetails",
                        principalColumn: "spaGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments_",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    SpaCustomersId = table.Column<Guid>(nullable: false),
                    SpaDetailsId = table.Column<Guid>(nullable: false),
                    SpaServicesId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments_", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments__SpaCustomers__SpaCustomersId",
                        column: x => x.SpaCustomersId,
                        principalTable: "SpaCustomers_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments__SpaDetails_SpaDetailsId",
                        column: x => x.SpaDetailsId,
                        principalTable: "SpaDetails",
                        principalColumn: "spaGuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments__SpaServices__SpaServicesId",
                        column: x => x.SpaServicesId,
                        principalTable: "SpaServices_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePays_",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CommisionPerJob = table.Column<decimal>(nullable: false),
                    GrossPay = table.Column<decimal>(nullable: false),
                    SpaUsersId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePays_", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePays__SpaUsers_SpaUsersId",
                        column: x => x.SpaUsersId,
                        principalTable: "SpaUsers",
                        principalColumn: "spaUserGuid",
                        onDelete: ReferentialAction.Cascade);
                });

        

            migrationBuilder.CreateTable(
                name: "CompletedJobs_",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AppointmentsId = table.Column<Guid>(nullable: false),
                    BusinessRetainedShare = table.Column<decimal>(nullable: false),
                    CompletionDate = table.Column<DateTime>(nullable: false),
                    CustomerFeedback = table.Column<string>(nullable: true),
                    CustomerRating = table.Column<int>(nullable: false),
                    EmployeeShare = table.Column<decimal>(nullable: false),
                    PaymentReference = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedJobs_", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedJobs__Appointments__AppointmentsId",
                        column: x => x.AppointmentsId,
                        principalTable: "Appointments_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments__SpaCustomersId",
                table: "Appointments_",
                column: "SpaCustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments__SpaDetailsId",
                table: "Appointments_",
                column: "SpaDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments__SpaServicesId",
                table: "Appointments_",
                column: "SpaServicesId");

       


          

            migrationBuilder.CreateIndex(
                name: "IX_CompletedJobs__AppointmentsId",
                table: "CompletedJobs_",
                column: "AppointmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePays__SpaUsersId",
                table: "EmployeePays_",
                column: "SpaUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaServices__SpaDetailsId",
                table: "SpaServices_",
                column: "SpaDetailsId");


          
           

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "CompletedJobs_");

            migrationBuilder.DropTable(
                name: "EmployeePays_");
            

            migrationBuilder.DropTable(
                name: "Appointments_");


            migrationBuilder.DropTable(
                name: "SpaCustomers_");

            migrationBuilder.DropTable(
                name: "SpaServices_");

        }
    }
}
