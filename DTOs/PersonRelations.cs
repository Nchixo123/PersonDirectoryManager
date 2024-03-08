using System.ComponentModel.DataAnnotations;

namespace DTOs;

public class PersonRelations
{
    public int FromId { get; set; }
    public Person? FromPerson { get; set; }
    public int ToId { get; set; }
    public Person? ToPerson { get; set; }

    public RelationType RelationType { get; set; }
}

public enum RelationType : byte
{
    Spouse = 0,
    Colleague = 1,
    Friend = 2,
    Relative = 3
}
