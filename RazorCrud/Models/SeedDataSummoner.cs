using Summoners.Model;
using Microsoft.EntityFrameworkCore;

namespace RazorCrud.Models;

public class SeedDataSummoner
{
    
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorCRUDSummonerContext(
                   serviceProvider.GetRequiredService<
                       DbContextOptions<RazorCRUDSummonerContext>>()))
        {
            // Look for any Summoners.
            if (context.Summoner.Any())
            {
                return;   // DB has been seeded
            }

            context.Summoner.AddRange(
                new Summoner
                {
                    Name = "Flash",
                    Effect = "Player blinks up to 400 units in the direction of the cursor",
                    Cooldown = 300 
                },

                new Summoner
                {
                    Name = "Ghost",
                    Effect = "Increases your champions movement speed and ignore unit collision",
                    Cooldown = 210
                }
                
            );
            context.SaveChanges();
        }
        
    }
    
}