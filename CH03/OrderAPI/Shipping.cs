using System;

public class Shipping
{
    private readonly IDatabase db;

    public void SetShippingAddress(Guid customerId,
        PostalAddress newAddress)
    {
        normalizeFields(newAddress);
        db.UpdateShippingAddress(customerId, newAddress);
    }

    private void normalizeFields(PostalAddress address)
    {
        address.FirstName = TextHelper.Capitalize(address.FirstName);
        address.LastName = TextHelper.Capitalize(address.LastName);
    }

    private void normalizeFields2(PostalAddress address)
    {
        address.FirstName = TextHelper.Capitalize(address.FirstName);
        address.LastName = TextHelper.Capitalize(address.LastName);
        address.City = TextHelper.Capitalize(address.City);
    }
}

internal interface IDatabase
{
    void UpdateShippingAddress(Guid customerId, PostalAddress newAddress);
}