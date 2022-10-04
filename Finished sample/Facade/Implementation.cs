namespace Facade;

/// <summary>
/// Facade
/// </summary>
public class DiscountFacade
{
    private readonly OrderService _orderService = new ();
    private readonly CustomerDiscountBaseService _customerDiscountBaseService = new ();
    private readonly DayOfTheWeekFactorService _dayOfTheWeekFactorService = new ();

    public double CalculateDiscountPercentage(int customerId)
    {
        if (!_orderService.HasEnoughOrders(customerId))
        {
            return 0;
        }

        return _customerDiscountBaseService.CalculateDiscountBase(customerId)
               * _dayOfTheWeekFactorService.CalculateDayOfTheWeekFactor();
    }
}
    
/// <summary>
/// Subsystem class
/// </summary>
public class OrderService
{
    public bool HasEnoughOrders(int customerId)
    {
        // does the customer have enough orders?  
        // fake calculation for demo purposes
        return (customerId > 5);
    }
}

/// <summary>
/// Subsystem class
/// </summary>
public class CustomerDiscountBaseService
{
    public double CalculateDiscountBase(int customerId)
    {
        // fake calculation for demo purposes
        return (customerId > 8) ? 10 : 20;
    }
}


/// <summary>
/// Subsystem class
/// </summary>
public class DayOfTheWeekFactorService
{
    public double CalculateDayOfTheWeekFactor() =>
        // fake calculation for demo purposes
        DateTime.UtcNow.DayOfWeek switch
        {
            DayOfWeek.Saturday => 0.8,
            DayOfWeek.Sunday => 0.8,
            DayOfWeek.Monday => 1.2,
            DayOfWeek.Tuesday => 1.2,
            DayOfWeek.Wednesday => 1.2,
            DayOfWeek.Thursday => 1.2,
            DayOfWeek.Friday => 1.2,
            _ => 1.2
        };
}