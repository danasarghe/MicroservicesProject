using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfigureOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        public static IEnumerable<Order> GetPreconfigureOrders()
        {
            return new List<Order>
            {
                new Order(){UserName = "swn", FirstName = "John", LastName = "Smith", EmailAddress = "dsarghe@gmail.com", AddressLine = "bla", Country = "Romania", TotalPrice = 350}
            };
        }
    }
}
