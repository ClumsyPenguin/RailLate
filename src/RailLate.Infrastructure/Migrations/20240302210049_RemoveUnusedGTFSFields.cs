using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailLate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnusedGTFSFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Pathways");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    level_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    level_index = table.Column<double>(type: "float", nullable: false),
                    level_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.level_id);
                });

            migrationBuilder.CreateTable(
                name: "Pathways",
                columns: table => new
                {
                    pathway_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    from_stop_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_bidirectional = table.Column<int>(type: "int", nullable: false),
                    length = table.Column<double>(type: "float", nullable: true),
                    max_slope = table.Column<double>(type: "float", nullable: true),
                    min_width = table.Column<double>(type: "float", nullable: true),
                    pathway_mode = table.Column<int>(type: "int", nullable: false),
                    reversed_signposted_as = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    signposted_as = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stair_count = table.Column<int>(type: "int", nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    to_stop_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    traversal_time = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pathways", x => x.pathway_id);
                });
        }
    }
}
