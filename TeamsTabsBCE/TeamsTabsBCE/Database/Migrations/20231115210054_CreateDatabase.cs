using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamsTabsBCE.Database.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskIdentifiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Week = table.Column<int>(type: "INTEGER", nullable: false),
                    List = table.Column<int>(type: "INTEGER", nullable: false),
                    Step = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskIdentifiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserEmail = table.Column<string>(type: "TEXT", nullable: false),
                    TaskIdentifierId = table.Column<int>(type: "INTEGER", nullable: false),
                    Result = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskResult_TaskIdentifiers_TaskIdentifierId",
                        column: x => x.TaskIdentifierId,
                        principalTable: "TaskIdentifiers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeamsConversation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConversationId = table.Column<string>(type: "TEXT", nullable: false),
                    TaskIdentifierId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsConversation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamsConversation_TaskIdentifiers_TaskIdentifierId",
                        column: x => x.TaskIdentifierId,
                        principalTable: "TaskIdentifiers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskIdentifiers_Week_List_Step",
                table: "TaskIdentifiers",
                columns: new[] { "Week", "List", "Step" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskResult_TaskIdentifierId",
                table: "TaskResult",
                column: "TaskIdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskResult_UserEmail_TaskIdentifierId",
                table: "TaskResult",
                columns: new[] { "UserEmail", "TaskIdentifierId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamsConversation_TaskIdentifierId",
                table: "TeamsConversation",
                column: "TaskIdentifierId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskResult");

            migrationBuilder.DropTable(
                name: "TeamsConversation");

            migrationBuilder.DropTable(
                name: "TaskIdentifiers");
        }
    }
}
