using System.ComponentModel.DataAnnotations;

public class ShipmentAddress {
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Address1 { get; set; }
  public string Address2 { get; set; }
  public string City { get; set; }

  [RegularExpression(@"^\s*\d{5}(-\d{4})?\s*$")]
  public string ZipCode { get; set; }

}
