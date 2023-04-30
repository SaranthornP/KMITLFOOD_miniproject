using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectKMITL.Migrations.SecondDB
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstnameDepositor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastnameDepositor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cafeteria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Restaurant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsernameDepository = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstnameDepository = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastnameDepository = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
