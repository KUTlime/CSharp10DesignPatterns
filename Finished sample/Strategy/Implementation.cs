namespace Strategy;

/// <summary>
/// Strategy
/// </summary>
public interface IExportService
{
    void Export(Order order);
}

/// <summary>
/// ConcreteStrategy
/// </summary>
public class JsonExportService : IExportService
{
    public void Export(Order order) => Console.WriteLine($"Exporting {order.Name} for {order.Amount} for {order.Customer} to Json.");
}

/// <summary>
/// ConcreteStrategy
/// </summary>
public class XmlExportService : IExportService
{
    public void Export(Order order) => Console.WriteLine($"Exporting {order.Name} for {order.Amount} for {order.Customer}  to XML.");
}

/// <summary>
/// ConcreteStrategy
/// </summary>
public class CsvExportService : IExportService
{
    public void Export(Order order) => Console.WriteLine($"Exporting {order.Name} for {order.Amount} for {order.Customer}  to CSV.");
}
   
/// <summary>
/// Context
/// </summary>
public record Order(string Customer, int Amount, string Name)
{
    public string? Description { get; set; }

    public void Export(IExportService exportService)
    {
        if (exportService is null)
        {
            throw new ArgumentNullException(nameof(exportService));
        }

        exportService.Export(this);
    }
}