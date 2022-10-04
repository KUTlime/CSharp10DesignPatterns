namespace Adapter.ObjectAdapter;

public record CityFromExternalSystem(string Name, string NickName, int Inhabitants);

/// <summary>
/// Adaptee
/// </summary>
public class ExternalSystem
{
    public CityFromExternalSystem GetCity() => new CityFromExternalSystem("Antwerp", "'t Stad", 500000);
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
public class CityAdapter : ICityAdapter
{
    private readonly ExternalSystem _externalSystem = new();

    public City GetCity()
    {
        // call into the external system 
        var cityFromExternalSystem = _externalSystem.GetCity();

        // adapt the CityFromExternalCity to a City 
        return new City(
            $"{cityFromExternalSystem.Name} - {cityFromExternalSystem.NickName}"
            , cityFromExternalSystem.Inhabitants);
    }
}