using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEB_API_DOT_NET.Migrations
{
    /// <inheritdoc />
    public partial class addingVilla77 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Private Pool, Beach Access, Outdoor Dining", new DateTime(2025, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luxury beachfront villa with private pool and panoramic ocean views.", "https://images.unsplash.com/photo-1505691723518-36a5ac3b2a5d", "Sunset Paradise Villa", 8, 350.0, 2500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Fireplace, Hiking Trails, Hot Tub", new DateTime(2025, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Secluded mountain retreat with fireplace, hiking trails, and scenic decks.", "https://images.unsplash.com/photo-1600585154340-be6161a56a0c", "Mountain Serenity Lodge", 6, 275.0, 1800, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Garden, BBQ Area, Outdoor Pool", new DateTime(2025, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tropical garden villa surrounded by palm trees, perfect for relaxation.", "https://images.unsplash.com/photo-1570129477492-45c003edd2be", "Palm Breeze Estate", 10, 400.0, 3200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Private Dock, Canoe, Fireplace", new DateTime(2025, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charming lakeside villa with private dock and fishing access.", "https://images.unsplash.com/photo-1599423300746-b62533397364", "Lakeside Haven", 5, 220.0, 1500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Rooftop Pool, City View, Concierge", new DateTime(2025, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Modern penthouse with skyline views, rooftop pool, and luxury interiors.", "https://images.unsplash.com/photo-1598928506310-4a03a2f9f2ed", "Urban Sky Penthouse", 4, 500.0, 1400, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
