internal interface IDatabase
{
    string GetCurrentCityByName(string normalizedFirstName, string normalizedLastName);

    bool UpdateCurrentCity(int id, string city);

    bool IsPersonActive(int id);
}