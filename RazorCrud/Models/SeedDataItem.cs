using Items.Model;
using Microsoft.EntityFrameworkCore;

namespace RazorCrud.Models;

public class SeedDataItem
{
    
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorCrudItemContext(
                   serviceProvider.GetRequiredService<
                       DbContextOptions<RazorCrudItemContext>>()))
        {
            // Look for any Items.
            if (context.Item.Any())
            {
                return;   // DB has been seeded
            }

            context.Item.AddRange(
                new Item
                {
                    Name = "Doran's ring",
                    Quality = "Starter",
                    Price = 400
                },

                new Item
                {
                    Name = "Long sword",
                    Quality = "base",
                    Price = 350
                }
                
            );
            context.SaveChanges();
        }
        
    }
    
}