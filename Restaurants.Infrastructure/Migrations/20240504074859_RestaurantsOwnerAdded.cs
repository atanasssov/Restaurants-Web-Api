﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurants.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RestaurantsOwnerAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Restaurants",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "Identifier of the owner");

            migrationBuilder.Sql("UPDATE RESTAURANTS SET OwnerId = (SELECT TOP 1 Id FROM AspNetUsers)");
            //migrationBuilder.Sql("UPDATE RESTAURANTS SET OwnerId = '0295aff0 - 2cb1 - 4527 - aa21 - 8d2da4f66f82'"); 

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_OwnerId",
                table: "Restaurants",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_AspNetUsers_OwnerId",
                table: "Restaurants",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_AspNetUsers_OwnerId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_OwnerId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Restaurants");
        }
    }
}
