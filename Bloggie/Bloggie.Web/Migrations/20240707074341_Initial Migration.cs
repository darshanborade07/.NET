﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Heading = table.Column<string>(type: "longtext", nullable: false),
                    PageTitle = table.Column<string>(type: "longtext", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    FeaturedImageUrl = table.Column<string>(type: "longtext", nullable: false),
                    UrlHandle = table.Column<string>(type: "longtext", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Author = table.Column<string>(type: "longtext", nullable: false),
                    Visible = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    DisplayName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BlogPostTag",
                columns: table => new
                {
                    BlogPostsId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TagsId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostTag", x => new { x.BlogPostsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_BlogPostTag_BlogPosts_BlogPostsId",
                        column: x => x.BlogPostsId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPostTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostTag_TagsId",
                table: "BlogPostTag",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostTag");

            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
