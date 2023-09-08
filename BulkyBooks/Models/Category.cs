using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBooks.Models;

public class Category
{
    [Key]
    public int id { get; set; }
    [Required]
    public string Name { get; set; }
    [DisplayName("Display Order")]
    [Range(1, 100, ErrorMessage ="Dont gimme that value")]
    public int DisplayOrder { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
