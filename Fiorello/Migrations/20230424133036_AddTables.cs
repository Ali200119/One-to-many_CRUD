using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoCover = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instagrams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instagrams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SliderInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignatureImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackgroundImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Advantages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutId = table.Column<int>(type: "int", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advantages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advantages_Abouts_AboutId",
                        column: x => x.AboutId,
                        principalTable: "Abouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Description", "SoftDelete", "Title", "VideoCover" },
                values: new object[] { 1, "Where flowers are our inspiration to create lasting memories. Whatever the occasion...", false, "<h1>Suprise Your <span>Valentine!</span> Let us arrange a smile.</h1>", "h3-video-img.jpg" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Description", "SoftDelete", "Title" },
                values: new object[] { 1, "A perfect blend of creativity, energy, communication, happiness and love. Let us arrange a smile for you.", false, "From our Blog" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SoftDelete" },
                values: new object[,]
                {
                    { 1, "Popular", false },
                    { 2, "Winter", false },
                    { 3, "Various", false },
                    { 4, "Exotic", false },
                    { 5, "Greens", false },
                    { 6, "Cactuses", false }
                });

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "Description", "SoftDelete", "Title" },
                values: new object[] { 1, "A perfect blend of creativity, energy, communication, happiness and love. Let us arrange a smile for you.", false, "Flower Experts" });

            migrationBuilder.InsertData(
                table: "Instagrams",
                columns: new[] { "Id", "Image", "SoftDelete" },
                values: new object[,]
                {
                    { 1, "instagram1.jpg", false },
                    { 2, "instagram2.jpg", false },
                    { 3, "instagram3.jpg", false },
                    { 4, "instagram4.jpg", false },
                    { 5, "instagram5.jpg", false },
                    { 6, "instagram6.jpg", false },
                    { 7, "instagram7.jpg", false },
                    { 8, "instagram8.jpg", false }
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Description", "Image", "Name", "Position", "SoftDelete" },
                values: new object[,]
                {
                    { 1, "Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus lingua.", "testimonial-img-1.png", "Anna Barnes", "Florist", false },
                    { 2, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget.", "testimonial-img-2.png", "Jasmine White", "Florist", false }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Key", "SoftDelete", "Value" },
                values: new object[,]
                {
                    { 1, "Header Logo", false, "logo.png" },
                    { 2, "Phone", false, "994501248723" },
                    { 3, "Email", false, "CodeAcademy@gmail.az" },
                    { 4, "Payment", false, "footer-bottom-1.png" }
                });

            migrationBuilder.InsertData(
                table: "SliderInfo",
                columns: new[] { "Id", "Description", "SignatureImage", "SoftDelete", "Title" },
                values: new object[] { 1, "Where flowers are our inspiration to create lasting memories. Whatever the occasion, our flowers will make it special cursus a sit amet mauris.", "h2-sign-img.png", false, "<h1>Send <span>flowers</span> like</h1><h1>you mean it</h1>" });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Image", "SoftDelete" },
                values: new object[,]
                {
                    { 1, "h3-slider-background.jpg", false },
                    { 2, "h3-slider-background-2.jpg", false },
                    { 3, "h3-slider-background-3.jpg", false }
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "Name", "SoftDelete" },
                values: new object[,]
                {
                    { 1, "LINKEDIN", false },
                    { 2, "FACEBOOK", false }
                });

            migrationBuilder.InsertData(
                table: "Subscribes",
                columns: new[] { "Id", "BackgroundImage", "SoftDelete", "Title" },
                values: new object[] { 1, "h3-background-img.jpg", false, "Join The Colorful Bunch!" });

            migrationBuilder.InsertData(
                table: "Advantages",
                columns: new[] { "Id", "AboutId", "Description", "Icon", "SoftDelete" },
                values: new object[,]
                {
                    { 1, 1, "Hand picked just for you.", "h1-custom-icon.png", false },
                    { 2, 1, "Unique flower arrangements.", "h1-custom-icon.png", false },
                    { 3, 1, "Best way to say you care.", "h1-custom-icon.png", false }
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "BlogId", "Date", "Description", "Image", "SoftDelete", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", "blog-feature-img-1.jpg", false, "Flower Power" },
                    { 2, 1, new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", "blog-feature-img-3.jpg", false, "Local Florists" },
                    { 3, 1, new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", "blog-feature-img-4.jpg", false, "Flower Beauty" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "ExpertId", "Image", "Name", "Position", "SoftDelete" },
                values: new object[,]
                {
                    { 1, 1, "h3-team-img-1.png", "CRYSTAL BROOKS", "Florist", false },
                    { 2, 1, "h3-team-img-2.png", "SHIRLEY HARRIS", "Manager", false },
                    { 3, 1, "h3-team-img-3.png", "BEVERLY CLARK", "Florist", false },
                    { 4, 1, "h3-team-img-4.png", "AMANDA WATKINS", "Florist", false }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Count", "Description", "Name", "Price", "SoftDelete" },
                values: new object[,]
                {
                    { 1, 6, 20, "Lorem ipsum", "1MAJESTY PALM", 259m, false },
                    { 2, 4, 20, "Lorem ipsum", "2MAJESTY PALM", 259m, false },
                    { 3, 3, 20, "Lorem ipsum", "3MAJESTY PALM", 259m, false },
                    { 4, 1, 20, "Lorem ipsum", "4MAJESTY PALM", 259m, false },
                    { 5, 2, 20, "Lorem ipsum", "5MAJESTY PALM", 259m, false },
                    { 6, 2, 20, "Lorem ipsum", "6MAJESTY PALM", 259m, false },
                    { 7, 4, 20, "Lorem ipsum", "7MAJESTY PALM", 259m, false },
                    { 8, 5, 20, "Lorem ipsum", "8MAJESTY PALM", 259m, true },
                    { 9, 5, 20, "Lorem ipsum", "9MAJESTY PALM", 259m, false }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMain", "Name", "ProductId", "SoftDelete" },
                values: new object[,]
                {
                    { 1, true, "shop-14-img.jpg", 1, false },
                    { 2, false, "shop-13-img.jpg", 1, false },
                    { 3, false, "shop-12-img.jpg", 1, false },
                    { 4, false, "shop-13-img.jpg", 2, false },
                    { 5, true, "shop-14-img.jpg", 2, false },
                    { 6, true, "shop-11-img.jpg", 3, false },
                    { 7, false, "shop-10-img.jpg", 3, false },
                    { 8, false, "shop-9-img.jpg", 3, false },
                    { 9, true, "shop-11-img.jpg", 4, false },
                    { 10, false, "shop-12-img.jpg", 4, false },
                    { 11, true, "shop-10-img.jpg", 5, false },
                    { 12, false, "shop-13-img.jpg", 5, false },
                    { 13, true, "shop-9-img.jpg", 6, false },
                    { 14, false, "shop-14-img.jpg", 6, false },
                    { 15, true, "shop-8-img.jpg", 7, false },
                    { 16, false, "shop-11-img.jpg", 7, false },
                    { 17, false, "shop-9-img.jpg", 7, false },
                    { 18, true, "shop-7-img.jpg", 8, false },
                    { 19, false, "shop-10-img.jpg", 8, false },
                    { 20, true, "shop-14-img.jpg", 9, false },
                    { 21, false, "shop-8-img.jpg", 9, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advantages_AboutId",
                table: "Advantages",
                column: "AboutId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_BlogId",
                table: "BlogPosts",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ExpertId",
                table: "Persons",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advantages");

            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Instagrams");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "SliderInfo");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "Subscribes");

            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
