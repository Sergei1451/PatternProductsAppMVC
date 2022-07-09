using Microsoft.EntityFrameworkCore;
using WebAppPatternProduct.Data;

namespace WebAppPatternProduct.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebAppPatternProductContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebAppPatternProductContext>>()))
            {
                
                if (context.ProductPOCO.Any())
                {
                    return; 
                }

                context.ProductPOCO.AddRange(
                    new ProductPOCO
                    {
                        Title = "Product_1",
                        ReleaseDate = DateTime.Parse("1950-1-10"),
                        CategoryProduct = "Category_Product_1",
                        Price = 10m
                    },

                     new ProductPOCO
                     {
                         Title = "Product_2",
                         ReleaseDate = DateTime.Parse("1960-2-10"),
                         CategoryProduct = "Category_Product_2",
                         Price = 11m
                     },

                     new ProductPOCO
                     {
                         Title = "Product_3",
                         ReleaseDate = DateTime.Parse("1970-3-10"),
                         CategoryProduct = "Category_Product_1",
                         Price = 12m
                     },

                     new ProductPOCO
                     {
                         Title = "Product_4",
                         ReleaseDate = DateTime.Parse("1980-4-10"),
                         CategoryProduct = "Category_Product_2",
                         Price = 13m
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
