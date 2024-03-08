using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOs;

public class City
{
    [Key]
    public int Id { get; set; }

    [Required, Column(TypeName = "nvarchar(30)")]
    public string Name { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime CreateDate { get; set; }

    [Column(TypeName = "byte")]
    public bool IsDelete { get; set; }

    public ICollection<Person>? People { get; set; }
}
