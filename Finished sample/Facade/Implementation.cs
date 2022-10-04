namespace Facade;

/// <summary>
/// Facade
/// </summary>
public static class DiscountFacade
{
    public static double CalculateDiscountPercentage(int customerId) => OrderService.HasEnoughOrders(customerId)
        ? CustomerDiscountBaseService.CalculateDiscountBase(customerId) * DayOfTheWeekFactorService.CalculateDayOfTheWeekFactor()
        : 0;
}
    
/// <summary>
/// Subsystem class
/// </summary>
public static class OrderService
{
    // does the customer have enough orders?
    // fake calculation for demo purposes
    public static bool HasEnoughOrders(int customerId) => (customerId > 5);
}

/// <summary>
/// Subsystem class
/// </summary>
public static class CustomerDiscountBaseService
{
    // fake calculation for demo purposes
    public static double CalculateDiscountBase(int customerId) => (customerId > 8) ? 10 : 20;
}


/// <summary>
/// Subsystem class
/// </summary>
public static class DayOfTheWeekFactorService
{
    // fake calculation for demo purposes
    public static double CalculateDayOfTheWeekFactor() => DateTime.UtcNow.DayOfWeek switch
    {
        DayOfWeek.Saturday => 0.8,
        DayOfWeek.Sunday => 0.8,
        _ => 1.2
    };
}