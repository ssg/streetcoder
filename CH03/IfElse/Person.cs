public class Person(int id, string firstName, string lastName, string city, IDatabase db)
{
    public int Id { get; set; } = id;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string City { get; set; } =  city;

    private readonly IDatabase db = db;

    public enum UpdateResult
    {
        Success,
        InvalidId,
        UpdateFailed,
        CityDidNotChange,
        InvalidName,
        PersonInactive
    }

    public UpdateResult UpdateCityIfChanged()
    {
        if (Id > 0)
        {
            bool isActive = db.IsPersonActive(Id);
            if (isActive)
            {
                if (FirstName != null && LastName != null)
                {
                    string normalizedFirstName = FirstName.ToUpper();
                    string normalizedLastName = LastName.ToUpper();
                    string currentCity = db.GetCurrentCityByName(
                      normalizedFirstName, normalizedLastName);
                    if (currentCity != City)
                    {
                        bool success = db.UpdateCurrentCity(Id, City);
                        if (success)
                        {
                            return UpdateResult.Success;
                        }
                        else
                        {
                            return UpdateResult.UpdateFailed;
                        }
                    }
                    else
                    {
                        return UpdateResult.CityDidNotChange;
                    }
                }
                else
                {
                    return UpdateResult.InvalidName;
                }
            }
            else
            {
                return UpdateResult.PersonInactive;
            }
        }
        else
        {
            return UpdateResult.InvalidId;
        }
    }

    public UpdateResult UpdateCityIfChanged2()
    {
        if (Id <= 0)
        {
            return UpdateResult.InvalidId;
        }
        bool isActive = db.IsPersonActive(Id);
        if (!isActive)
        {
            return UpdateResult.PersonInactive;
        }
        if (FirstName is null || LastName is null)
        {
            return UpdateResult.InvalidName;
        }
        string normalizedFirstName = FirstName.ToUpper();
        string normalizedLastName = LastName.ToUpper();
        string currentCity = db.GetCurrentCityByName(
          normalizedFirstName, normalizedLastName);
        if (currentCity == City)
        {
            return UpdateResult.CityDidNotChange;
        }
        bool success = db.UpdateCurrentCity(Id, City);
        if (!success)
        {
            return UpdateResult.UpdateFailed;
        }
        return UpdateResult.Success;
    }
}