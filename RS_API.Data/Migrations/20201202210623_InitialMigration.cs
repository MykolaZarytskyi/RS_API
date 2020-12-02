using Microsoft.EntityFrameworkCore.Migrations;

namespace RS_API.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Car_type = table.Column<string>(nullable: false),
                    PassengersCount = table.Column<int>(nullable: true),
                    Capacity = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "Car_type", "Mark", "Model", "PassengersCount" },
                values: new object[,]
                {
                    { 5, "PassengerCar", "BMW", "M2", 5 },
                    { 6, "PassengerCar", "BMW", "X3M", 5 },
                    { 7, "PassengerCar", "BMW", "Z4", 2 },
                    { 8, "PassengerCar", "VOLVO", "S40", 5 }
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "Car_type", "Mark", "Model", "Capacity" },
                values: new object[,]
                {
                    { 1, "TruckCar", "MAN", "TGX EVOLION", 15.0 },
                    { 2, "TruckCar", "MAN", "MAN XLION", 18.0 },
                    { 3, "TruckCar", "DAF", "XF", 12.0 },
                    { 4, "TruckCar", "DAF", "CF", 14.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");
        }
    }
}
