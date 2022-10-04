using Facade;
 
Console.WriteLine($"Discount percentage for customer with id 1: {DiscountFacade.CalculateDiscountPercentage(1)}");
Console.WriteLine($"Discount percentage for customer with id 10: {DiscountFacade.CalculateDiscountPercentage(10)}");

Console.ReadKey();