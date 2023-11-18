using System.ComponentModel.DataAnnotations;

public class ShipmentAddress
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Address1 { get; set; }
    public required string Address2 { get; set; }
    public required string City { get; set; }

    [RegularExpression(@"^\s*\d{5}(-\d{4})?\s*$")]
    public required string ZipCode { get; set; }

}
