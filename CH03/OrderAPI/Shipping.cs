using System;

public class Shipping(IDatabase db)
{
    public void SetShippingAddress(Guid customerId,
        PostalAddress newAddress)
    {
        NormalizeFields(newAddress);
        db.UpdateShippingAddress(customerId, newAddress);
    }

    protected static void NormalizeFields(PostalAddress address)
    {
        address.FirstName = TextHelper.Capitalize(address.FirstName);
        address.LastName = TextHelper.Capitalize(address.LastName);
    }

    protected static void NormalizeFields2(PostalAddress address)
    {
        address.FirstName = TextHelper.Capitalize(address.FirstName);
        address.LastName = TextHelper.Capitalize(address.LastName);
        address.City = TextHelper.Capitalize(address.City);
    }
}

public interface IDatabase
{
    void UpdateShippingAddress(Guid customerId, PostalAddress newAddress);
}