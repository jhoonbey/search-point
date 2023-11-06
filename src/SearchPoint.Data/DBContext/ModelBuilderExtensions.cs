using Microsoft.EntityFrameworkCore;
using SearchPoint.Data.Entities;

namespace SearchPoint.Data.DBContext
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            // generate random 200 rectangles
            List<Rectangle> rectangles = new();
            for (int i = 1; i <= 200; i++)
            {
                Rectangle rectangle = new()
                {
                    Id = i,
                    BottomLeftX = new Random().Next(0, 500),
                    BottomLeftY = new Random().Next(0, 500),
                    CreateDate = DateTime.UtcNow
                };

                // add random width and height
                rectangle.TopRightX = rectangle.BottomLeftX + new Random().Next(5, 30);
                rectangle.TopRightY = rectangle.BottomLeftY + new Random().Next(5, 30);

                rectangles.Add(rectangle);
            }


            modelBuilder.Entity<Rectangle>()
              .HasData(rectangles);

        }
    }
}

