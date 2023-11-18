public class PostalAddress(string firstName, string lastName, string address1, string address2, string city, string zipCode, string notes)
{
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string Address1 { get; set; } = address1;
    public string Address2 { get; set; } = address2;
    public string City { get; set; } = city;
    public string ZipCode { get; set; } = zipCode;
    public string Notes { get; set; } = notes;
}