using Champions.Model;
using Microsoft.EntityFrameworkCore;

namespace RazorCrud.Models;


public class SeedData
{

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorCrudChampionContext(
                   serviceProvider.GetRequiredService<
                       DbContextOptions<RazorCrudChampionContext>>()))
        {
            // Look for any Champions.
            if (context.Champion.Any())
            {
                return;   // DB has been seeded
            }

            context.Champion.AddRange(
                new Champion
                {
                    Name = "Ornn",
                    ReleaseDate = DateTime.Parse("2017-10-23"),
                    Role = "Top",
                    Price = 6300
                },

                new Champion
                {
                    Name = "Aatrox",
                    ReleaseDate = DateTime.Parse("2013-6-13"),
                    Role = "Top",
                    Price = 4800
                }
                
            );
            context.SaveChanges();
        }
        
    }
    
}