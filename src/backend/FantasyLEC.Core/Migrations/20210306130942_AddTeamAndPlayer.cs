using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FantasyLEC.Core.Migrations
{
    public partial class AddTeamAndPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    AveragePoints = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    SummonerName = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    AveragePoints = table.Column<double>(type: "double precision", nullable: false),
                    CountryCode = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "AveragePoints", "Code", "Image", "Name" },
                values: new object[,]
                {
                    { 9, 0.0, "SK", "http://static.lolesports.com/teams/SK_FullColor.png", "SK Gaming" },
                    { 6, 0.0, "AST", "http://static.lolesports.com/teams/AST-FullonDark.png", "Astralis" },
                    { 7, 0.0, "XL", "http://static.lolesports.com/teams/Excel_FullColor2.png", "EXCEL Esports" },
                    { 3, 0.0, "RGE", "http://static.lolesports.com/teams/Rogue_FullColor2.png", "Rogue" },
                    { 4, 0.0, "MAD", "http://static.lolesports.com/teams/1592591395339_MadLionsMAD-01-FullonDark.png", "MAD Lions" },
                    { 2, 0.0, "FNC", "http://static.lolesports.com/teams/1592591295307_FnaticFNC-01-FullonDark.png", "Fnatic" },
                    { 1, 0.0, "G2", "http://static.lolesports.com/teams/G2-FullonDark.png", "G2 Esports" },
                    { 8, 0.0, "MSF", "http://static.lolesports.com/teams/1592591419157_MisfitsMSF-01-FullonDark.png", "Misfits Gaming" },
                    { 5, 0.0, "S04", "http://static.lolesports.com/teams/S04_Standard_Logo1.png", "FC Schalke 04 Esports" },
                    { 10, 0.0, "VIT", "http://static.lolesports.com/teams/1592591570387_VitalityVIT-01-FullonDark.png", "Team Vitality" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "AveragePoints", "CountryCode", "FirstName", "Image", "LastName", "Role", "SummonerName", "TeamId" },
                values: new object[,]
                {
                    { 90, 0.0, "de", "Janik", "http://static.lolesports.com/players/SK_JENAX.png", "Bartels", 0, "Jenax", 9 },
                    { 22, 0.0, "be", "Yasin", "http://static.lolesports.com/players/FNC_NISQY.png", "Dincer", 2, "Nisqy", 2 },
                    { 23, 0.0, "de", "Elias", "http://static.lolesports.com/players/FNC_UPSET.png", "Lipp", 3, "Upset", 2 },
                    { 11, 0.0, "pl", "Marcin", "http://static.lolesports.com/players/G2_JANKOS.png", "Jankowski", 1, "Jankos", 1 },
                    { 10, 0.0, "dk", "Martin", "http://static.lolesports.com/players/G2_WUNDER.png", "Hansen", 0, "Wunder", 1 },
                    { 14, 0.0, "si", "Mihael", "http://static.lolesports.com/players/G2_MICKYX.png", "Mehle", 4, "Mikyx", 1 },
                    { 12, 0.0, "dk", "Rasmus", "http://static.lolesports.com/players/G2_CAPS.png", "Winther", 2, "Caps", 1 },
                    { 13, 0.0, "se", "Martin", "http://static.lolesports.com/players/G2_REKKLES.png", "Larsson", 3, "Rekkles", 1 },
                    { 81, 0.0, "es", "Iván", "http://static.lolesports.com/players/MSF_RAZORK.png", "Martín", 1, "Razork", 8 },
                    { 89, 0.0, "cz", "Petr", "http://static.lolesports.com/players/MSF_DENYK.png", "Haramach", 4, "denyk", 8 },
                    { 83, 0.0, "dk", "Kasper", "http://static.lolesports.com/players/MSF_KOBBE.png", "Kobberup", 3, "Kobbe", 8 },
                    { 85, 0.0, "pl", "Tobiasz", "http://static.lolesports.com/players/MSF_AGRESIVOO.png", "Ciba", 0, "Agresivoo", 8 },
                    { 80, 0.0, "kr", "Shin", "http://static.lolesports.com/players/MSF_HIRIT.png", "Tae-min", 0, "HiRit", 8 },
                    { 82, 0.0, "fr", "Vincent", "http://static.lolesports.com/players/MSF_VETHEO.png", "Berrié", 2, "Vetheo", 8 },
                    { 84, 0.0, "pl", "Oskar", "http://static.lolesports.com/players/MSF_VANDER.png", "Bogdan", 4, "Vander", 8 },
                    { 52, 0.0, "de", "Felix", "http://static.lolesports.com/players/S04_Abbedagge.png", "Braun", 2, "Abbedagge", 5 },
                    { 53, 0.0, "sk", "Matus", "http://static.lolesports.com/players/S04_Neon.png", "Jakubcik", 3, "Neon", 5 },
                    { 51, 0.0, "de", "Erberk", "http://static.lolesports.com/players/S04_Gilius.png", "Demir", 1, "Gilius", 5 },
                    { 50, 0.0, "de", "Sergen", "http://static.lolesports.com/players/S04_BrokenBlade.png", "Çelik", 0, "BrokenBlade", 5 },
                    { 54, 0.0, "hr", "Dino", "http://static.lolesports.com/players/S04_Limit.png", "Tot", 4, "LIMIT", 5 },
                    { 101, 0.0, "fr", "Duncan", "http://static.lolesports.com/players/VIT_SKEANZ.png", "Marquet", 1, "Skeanz", 10 },
                    { 108, 0.0, "gr", "Markos", "http://static.lolesports.com/players/VIT_COMP.png", "Stamkopoulos", 3, "Comp", 10 },
                    { 102, 0.0, "rs", "Aljoša", "http://static.lolesports.com/players/VIT_MILICA.png", "Kovandžić", 2, "Milica", 10 },
                    { 104, 0.0, "gr", "Labros", "http://static.lolesports.com/players/VIT_LABROV.png", "Papoutsakis", 4, "Labrov", 10 },
                    { 21, 0.0, "pl", "Oskar", "http://static.lolesports.com/players/FNC_SELFMADE.png", "Boderek", 1, "Selfmade", 2 },
                    { 20, 0.0, "be", "Gabriel", "http://static.lolesports.com/players/FNC_BWIPO.png", "Rau", 0, "Bwipo", 2 },
                    { 24, 0.0, "bg", "Zdravets", "http://static.lolesports.com/players/FNC_HYLISSANG.png", "Iliev Galabov", 4, "Hylissang", 2 },
                    { 41, 0.0, "es", "Javier", "http://static.lolesports.com/players/MAD_Elyoya.png", "Prades", 1, "Elyoya", 4 },
                    { 91, 0.0, "dk", "Kristian", "http://static.lolesports.com/players/SK_TYNX.png", "Østergaard Hansen", 1, "TynX", 9 },
                    { 93, 0.0, "fr", "Jean", "http://static.lolesports.com/players/SK_JEZU.png", "Massol", 3, "Jezu", 9 },
                    { 94, 0.0, "se", "Erik", "http://static.lolesports.com/players/SK_TREATZ.png", "Wessén", 4, "Treatz", 9 },
                    { 92, 0.0, "be", "Ersin", "http://static.lolesports.com/players/SK_BLUE.png", "Gören", 2, "Blue", 9 },
                    { 62, 0.0, "no", "Erlend", "http://static.lolesports.com/players/AST_NUKEDUCK.png", "Holm", 2, "nukeduck", 6 },
                    { 60, 0.0, "fi", "Matti", "http://static.lolesports.com/players/AST_WHITEKNIGHT.png", "Sormunen", 0, "WhiteKnight", 6 },
                    { 61, 0.0, "ru", "Nikolay", "http://static.lolesports.com/players/AST_ZANZARAH.png", "Akatov", 1, "Zanzarah", 6 },
                    { 63, 0.0, "se", "Jesper Klarin", "http://static.lolesports.com/players/AST_JESKLA.png", "Stromberg", 3, "Jeskla", 6 },
                    { 64, 0.0, "se", "Hampus", "http://static.lolesports.com/players/AST_PROMISQ.png", "Abrahamsson", 4, "promisq", 6 },
                    { 67, 0.0, "se", "Felix", "https://lolstatic-a.akamaihd.net/esports-assets/production/player/magifelix-f98zv79q.png", "Boström", 2, "MagiFelix", 6 },
                    { 73, 0.0, "cz", "Patrik", "http://static.lolesports.com/players/XL_PATRIK.png", "Jiru", 3, "Patrik", 7 },
                    { 100, 0.0, "dk", "Mathias", "http://static.lolesports.com/players/VIT_SZYGENDA.png", "Jensen", 0, "Szygenda", 10 },
                    { 74, 0.0, "no", "Tore", "http://static.lolesports.com/players/XL_TORE.png", "Hoel Eilertsen", 4, "Tore", 7 },
                    { 71, 0.0, "gb", "Daniel", "http://static.lolesports.com/players/XL_DAN.png", "Hockley", 1, "Dan", 7 },
                    { 72, 0.0, "pl", "Pavel", "http://static.lolesports.com/players/XL_CZEKOLAD.png", "Szczepanik", 2, "Czekolad", 7 },
                    { 32, 0.0, "se", "Emil", "http://static.lolesports.com/players/RGE_LARSSEN.png", "Larsson", 2, "Larssen", 3 },
                    { 31, 0.0, "pl", "Kacper", "http://static.lolesports.com/players/RGE_INSPIRED.png", "Sloma", 1, "Inspired", 3 },
                    { 33, 0.0, "fr", "Steven", "http://static.lolesports.com/players/RGE_HANS_SAMA.png", "Liv", 3, "Hans sama", 3 },
                    { 30, 0.0, "ro", "Andrei", "http://static.lolesports.com/players/RGE_ODOAMNE.png", "Pascu", 0, "Odoamne", 3 },
                    { 34, 0.0, "pl", "Adrian", "http://static.lolesports.com/players/RGE_TRYMBI.png", "Trybus", 4, "Trymbi", 3 },
                    { 42, 0.0, "cz", " Marek", "http://static.lolesports.com/players/MAD_Humanoid.png", "Brázda", 2, "Humanoid", 4 },
                    { 43, 0.0, "cz", "Matyáš", "http://static.lolesports.com/players/MAD_Carzzy.png", "Orság", 3, "Carzzy", 4 },
                    { 44, 0.0, "de", "Norman", "http://static.lolesports.com/players/MAD_Kaiser.png", "Kaiser", 4, "Kaiser", 4 },
                    { 40, 0.0, "tr", "İrfan", "http://static.lolesports.com/players/MAD_Armut.png", "Tükek", 0, "Armut", 4 },
                    { 70, 0.0, "se", "Felix", "http://static.lolesports.com/players/XL_KRYZE.png", "Hellström", 0, "Kryze", 7 },
                    { 103, 0.0, "si", "Jus", "http://static.lolesports.com/players/1591899881632_Ju-CROWNSHOT-Marui-1.png", "Marusic", 3, "Crownshot", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_SummonerName",
                table: "Players",
                column: "SummonerName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
