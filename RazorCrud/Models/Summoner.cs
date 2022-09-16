namespace Summoners.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Summoner
{
    public int ID { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string Name { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
    [Required]
    public string Effect { get; set; }

    [Range(50, 4000)]
    [DataType(DataType.Text)]
    public int Cooldown { get; set; }
    
}