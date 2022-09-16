namespace Champions.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Champion
{
    public int ID { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string Name { get; set; }

    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [Range(450, 6300)]
    [DataType(DataType.Text)]
    public int Price { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
    [Required]
    [StringLength(30)]
    public string Role { get; set; }
    
}