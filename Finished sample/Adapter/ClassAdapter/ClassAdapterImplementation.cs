namespace Adapter.ClassAdapter;

public record CityFromExternalSystem(string Name, string NickName, int Inhabitants);

/// <summary>
/// Adaptee
/// </summary>
public class ExternalSystem
{
    public CityFromExternalSystem GetCity() => new("Antwerp", "'t Stad", 500000);
}

public record City(string FullName, long Inhabitants);

/// <summary>
/// Target
/// </summary>
public interface ICityAdapter
{
    City GetCity();
}

/// <summary>
/// Adapter
/// </summary>
public class CityAdapter : ExternalSystem, ICityAdapter
{
    public City GetCity()
    {
        // call into the external system
        var cityFromExternalSystem = base.GetCity();

        // adapt the CityFromExternalCity to a City
        return new City(
            $"{cityFromExternalSystem.Name} - {cityFromExternalSystem.NickName}"
            , cityFromExternalSystem.Inhabitants);
    }
}