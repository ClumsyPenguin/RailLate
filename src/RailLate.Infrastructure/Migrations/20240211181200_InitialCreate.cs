using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailLate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    agency_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    agency_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    agency_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    agency_timezone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    agency_lang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    agency_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    agency_fare_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    agency_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.agency_id);
                });

            migrationBuilder.CreateTable(
                name: "CalendarDates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    service_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    service_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mask = table.Column<byte>(type: "tinyint", nullable: false),
                    monday = table.Column<bool>(type: "bit", nullable: false),
                    tuesday = table.Column<bool>(type: "bit", nullable: false),
                    wednesday = table.Column<bool>(type: "bit", nullable: false),
                    thursday = table.Column<bool>(type: "bit", nullable: false),
                    friday = table.Column<bool>(type: "bit", nullable: false),
                    saturday = table.Column<bool>(type: "bit", nullable: false),
                    sunday = table.Column<bool>(type: "bit", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FareAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fare_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    currency_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    payment_method = table.Column<int>(type: "int", nullable: false),
                    transfers = table.Column<long>(type: "bigint", nullable: false),
                    agency_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transfer_duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FareAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FareRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fare_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    route_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    origin_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destination_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contains_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FareRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    feed_publisher_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    feed_publisher_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    feed_lang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    feed_start_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    feed_end_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    feed_version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Frequencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    trip_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    end_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    headway_secs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exact_times = table.Column<bool>(type: "bit", nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    level_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    level_index = table.Column<double>(type: "float", nullable: false),
                    level_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    to_stop_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pathway_mode = table.Column<int>(type: "int", nullable: false),
                    is_bidirectional = table.Column<int>(type: "int", nullable: false),
                    length = table.Column<double>(type: "float", nullable: true),
                    traversal_time = table.Column<int>(type: "int", nullable: true),
                    stair_count = table.Column<int>(type: "int", nullable: true),
                    max_slope = table.Column<double>(type: "float", nullable: true),
                    min_width = table.Column<double>(type: "float", nullable: true),
                    signposted_as = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reversed_signposted_as = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pathways", x => x.pathway_id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    route_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    agency_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    route_short_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    route_long_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    route_desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    route_type = table.Column<int>(type: "int", nullable: false),
                    route_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    route_color = table.Column<int>(type: "int", nullable: true),
                    route_text_color = table.Column<int>(type: "int", nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.route_id);
                });

            migrationBuilder.CreateTable(
                name: "Shapes",
                columns: table => new
                {
                    shape_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    shape_pt_lat = table.Column<double>(type: "float", nullable: false),
                    shape_pt_lon = table.Column<double>(type: "float", nullable: false),
                    shape_pt_sequence = table.Column<long>(type: "bigint", nullable: false),
                    shape_dist_traveled = table.Column<double>(type: "float", nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shapes", x => x.shape_id);
                });

            migrationBuilder.CreateTable(
                name: "StopTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    trip_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    arrival_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    departure_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    stop_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stop_sequence = table.Column<long>(type: "bigint", nullable: false),
                    stop_headsign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pickup_type = table.Column<int>(type: "int", nullable: true),
                    drop_off_type = table.Column<int>(type: "int", nullable: true),
                    shape_dist_traveled = table.Column<double>(type: "float", nullable: true),
                    timepoint = table.Column<int>(type: "int", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StopTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stops",
                columns: table => new
                {
                    stop_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    stop_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stop_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stop_desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stop_lat = table.Column<double>(type: "float", nullable: false),
                    stop_lon = table.Column<double>(type: "float", nullable: false),
                    zone_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stop_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location_type = table.Column<int>(type: "int", nullable: true),
                    parent_station = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stop_timezone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wheelchair_boarding = table.Column<string>(name: " wheelchair_boarding ", type: "nvarchar(max)", nullable: false),
                    level_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    platform_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stops", x => x.stop_id);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    from_stop_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    to_stop_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transfer_type = table.Column<int>(type: "int", nullable: false),
                    min_transfer_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    trip_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    route_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    service_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trip_headsign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trip_short_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direction_id = table.Column<int>(type: "int", nullable: true),
                    block_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shape_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wheelchair_accessible = table.Column<int>(type: "int", nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.trip_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "CalendarDates");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropTable(
                name: "FareAttributes");

            migrationBuilder.DropTable(
                name: "FareRules");

            migrationBuilder.DropTable(
                name: "FeedInfos");

            migrationBuilder.DropTable(
                name: "Frequencies");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Pathways");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Shapes");

            migrationBuilder.DropTable(
                name: "StopTimes");

            migrationBuilder.DropTable(
                name: "Stops");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
