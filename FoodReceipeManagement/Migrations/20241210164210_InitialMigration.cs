using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodReceipeManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementUnit",
                columns: table => new
                {
                    MeasurementUnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnit", x => x.MeasurementUnitId);
                });

            migrationBuilder.CreateTable(
                name: "Receipes",
                columns: table => new
                {
                    ReceipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CookingTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipes", x => x.ReceipeId);
                });

            migrationBuilder.CreateTable(
                name: "ReceipeIngredients",
                columns: table => new
                {
                    ReceipeIngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceipeId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    MeasurementUnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceipeIngredients", x => x.ReceipeIngredientId);
                    table.ForeignKey(
                        name: "FK_ReceipeIngredients_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceipeIngredients_MeasurementUnit_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnit",
                        principalColumn: "MeasurementUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceipeIngredients_Receipes_ReceipeId",
                        column: x => x.ReceipeId,
                        principalTable: "Receipes",
                        principalColumn: "ReceipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceipeInstructions",
                columns: table => new
                {
                    ReceipeInstructionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceipeId = table.Column<int>(type: "int", nullable: false),
                    InstructionOrderId = table.Column<int>(type: "int", nullable: false),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceipeInstructions", x => x.ReceipeInstructionId);
                    table.ForeignKey(
                        name: "FK_ReceipeInstructions_Receipes_ReceipeId",
                        column: x => x.ReceipeId,
                        principalTable: "Receipes",
                        principalColumn: "ReceipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "IngredientId", "Name" },
                values: new object[,]
                {
                    { 1, "Apples" },
                    { 2, "Sugar" },
                    { 3, "Cinnamon" },
                    { 4, "Pie Dough" },
                    { 5, "Butter" }
                });

            migrationBuilder.InsertData(
                table: "MeasurementUnit",
                columns: new[] { "MeasurementUnitId", "Name" },
                values: new object[,]
                {
                    { 1, "Ounce" },
                    { 2, "Tablespoon" },
                    { 3, "Teaspoon" },
                    { 4, "Cups" },
                    { 5, "Cup" }
                });

            migrationBuilder.InsertData(
                table: "Receipes",
                columns: new[] { "ReceipeId", "CookingTime", "Description", "Name" },
                values: new object[] { 1, 60, "Bake and cool the pie, and then top with vanilla ice cream for the ultimate dessert.", "Apple Pie" });

            migrationBuilder.InsertData(
                table: "ReceipeIngredients",
                columns: new[] { "ReceipeIngredientId", "IngredientId", "MeasurementUnitId", "Quantity", "ReceipeId" },
                values: new object[,]
                {
                    { 1, 1, 4, 6.0, 1 },
                    { 2, 2, 5, 0.75, 1 },
                    { 3, 3, 3, 1.0, 1 },
                    { 4, 4, 1, 14.1, 1 },
                    { 5, 5, 2, 1.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "ReceipeInstructions",
                columns: new[] { "ReceipeInstructionId", "Instruction", "InstructionOrderId", "ReceipeId" },
                values: new object[,]
                {
                    { 1, "Gather the ingredients. Preheat the oven to 450 degrees F (230 degrees C)", 1, 1 },
                    { 2, "Line a 9-inch pie dish with one pastry crust; set second one aside.", 2, 1 },
                    { 3, "Combine 3/4 cup sugar and cinnamon in a small bowl. Add more sugar if your apples are tart", 3, 1 },
                    { 4, "Layer apple slices in the prepared pie dish, sprinkling each layer with cinnamon-sugar mixture", 4, 1 },
                    { 5, "Dot top layer with small pieces of butter. Cover with top crust", 5, 1 },
                    { 6, "Bake pie on the lowest rack of the preheated oven for 10 minutes. Reduce oven temperature to 350 degrees F (175 degrees C) and continue baking until golden brown and filling bubbles, 30 to 35 minutes more", 6, 1 },
                    { 7, "Serve warm or cold.", 7, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_Name",
                table: "Ingredient",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementUnit_Name",
                table: "MeasurementUnit",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceipeIngredients_IngredientId",
                table: "ReceipeIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceipeIngredients_MeasurementUnitId",
                table: "ReceipeIngredients",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceipeIngredients_ReceipeId",
                table: "ReceipeIngredients",
                column: "ReceipeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceipeInstructions_ReceipeId",
                table: "ReceipeInstructions",
                column: "ReceipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipes_Name",
                table: "Receipes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceipeIngredients");

            migrationBuilder.DropTable(
                name: "ReceipeInstructions");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "MeasurementUnit");

            migrationBuilder.DropTable(
                name: "Receipes");
        }
    }
}
