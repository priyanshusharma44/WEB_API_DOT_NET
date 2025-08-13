using Microsoft.EntityFrameworkCore;
using WEB_API_DOT_NET.Models;

namespace WEB_API_DOT_NET.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
        
        }
        
        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Sunset Paradise Villa",
                    Details = "Luxury beachfront villa with private pool and panoramic ocean views.",
                    ImageUrl = "https://images.unsplash.com/photo-1505691723518-36a5ac3b2a5d",
                    Occupancy = 8,
                    Rate = 350,
                    Sqft = 2500,
                    Amenity = "Private Pool, Beach Access, Outdoor Dining",
                    CreatedDate = new DateTime(2025, 08, 12)
                },
                new Villa()
                {
                    Id = 2,
                    Name = "Mountain Serenity Lodge",
                    Details = "Secluded mountain retreat with fireplace, hiking trails, and scenic decks.",
                    ImageUrl = "https://images.unsplash.com/photo-1600585154340-be6161a56a0c",
                    Occupancy = 6,
                    Rate = 275,
                    Sqft = 1800,
                    Amenity = "Fireplace, Hiking Trails, Hot Tub",
                    CreatedDate = new DateTime(2025, 08, 12)
                },
                new Villa()
                {
                    Id = 3,
                    Name = "Palm Breeze Estate",
                    Details = "Tropical garden villa surrounded by palm trees, perfect for relaxation.",
                    ImageUrl = "https://images.unsplash.com/photo-1570129477492-45c003edd2be",
                    Occupancy = 10,
                    Rate = 400,
                    Sqft = 3200,
                    Amenity = "Garden, BBQ Area, Outdoor Pool",
                    CreatedDate = new DateTime(2025, 08, 12)
                },
                new Villa()
                {
                    Id = 4,
                    Name = "Lakeside Haven",
                    Details = "Charming lakeside villa with private dock and fishing access.",
                    ImageUrl = "https://images.unsplash.com/photo-1599423300746-b62533397364",
                    Occupancy = 5,
                    Rate = 220,
                    Sqft = 1500,
                    Amenity = "Private Dock, Canoe, Fireplace",
                    CreatedDate = new DateTime(2025, 08, 12)
                },
                new Villa()
                {
                    Id = 5,
                    Name = "Urban Sky Penthouse",
                    Details = "Modern penthouse with skyline views, rooftop pool, and luxury interiors.",
                    ImageUrl = "https://images.unsplash.com/photo-1598928506310-4a03a2f9f2ed",
                    Occupancy = 4,
                    Rate = 500,
                    Sqft = 1400,
                    Amenity = "Rooftop Pool, City View, Concierge",
                    CreatedDate = new DateTime(2025, 08, 12)
                }
            );
        }


    }
}
