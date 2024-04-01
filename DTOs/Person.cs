using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Validations;


namespace DTOs;

public class Person
{
    [Key]
    public int Id { get; set; }

    [Required, EnglishOrGeorgian, MinLength(2, ErrorMessage = "Invalid input"), MaxLength(50, ErrorMessage = "Invalid input"), Column(TypeName = "nvarchar(50)")]
    public string FirstName { get; set; } = null!;

    [Required,EnglishOrGeorgian ,MinLength(2, ErrorMessage = "Invalid input"), MaxLength(50, ErrorMessage = "Invalid input"), Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; } = null!;

    [Required, MinLength(11, ErrorMessage = "Invalid input"), MaxLength(11, ErrorMessage = "Invalid input"), Column(TypeName = "nvarchar(11)")]
    public string PIN { get; set; } = null!;

    [Required, Column(TypeName = "Date")]
    public DateTime BirthDate { get; set; }

    [Required]
    public Gender Gender { get; set; }

    [Required, Column(TypeName = "nvarchar(75)")]
    public string Address { get; set; } = null!;

    [Required, MinLength(4, ErrorMessage = "Invalid input"), MaxLength(50, ErrorMessage = "Invalid input"), Column(TypeName = "nvarchar(18)")]
    public string PersonalNumber { get; set; } = null!;

    [MinLength(4, ErrorMessage = "Invalid input"), MaxLength(50, ErrorMessage = "Invalid input"), Column(TypeName = "nvarchar(50)")]
    public string? OfficeNumber { get; set; }

    [MinLength(4, ErrorMessage = "Invalid input"), MaxLength(50, ErrorMessage = "Invalid input"), Column(TypeName = "nvarchar(50)")]
    public string? HomeNumber { get; set; }

    [Column(TypeName = "Date")]
    public DateTime CreateDate { get; set; } = DateTime.Now;

    [Required, Column(TypeName = "Varbinary(max)")]
    public byte[] Picture { get; set; } = null!;

    [Column(TypeName = "int")]
    public bool IsDelete { get; set; }

    public int CityId { get; set; }

    public City City { get; set; } = null!;

    public ICollection<PersonRelations>? FromRelationships { get; set; }
    public ICollection<PersonRelations>? ToRelationships { get; set; }
}
public enum Gender : byte
{
    Male = 0,
    Female = 1
}
