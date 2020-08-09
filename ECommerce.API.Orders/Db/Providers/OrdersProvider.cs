using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.API.Orders.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.API.Orders.Db.Providers
{
    public class OrdersProvider : IOrdersProvider
    {
        private readonly OrdersDbContext dbContext;
        private readonly ILogger<OrdersProvider> logger;
        private readonly IMapper mapper;

        public OrdersProvider(OrdersDbContext dbContext, ILogger<OrdersProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!dbContext.Orders.Any())
            {
                dbContext.Orders.Add(new Order() { Id = 1, OrderDate=DateTime.Now, Total=45, CustomerId = 1, Items = new List<OrderItem>() { new OrderItem() { Id = 5, OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 2 }, new OrderItem() { Id = 9, OrderId = 1, ProductId = 2, Quantity = 5, UnitPrice = 12 } } });
                dbContext.Orders.Add(new Order() { Id = 2, OrderDate = DateTime.Now, Total = 34, CustomerId = 2, Items = new List<OrderItem>() { new OrderItem() { Id = 6, OrderId = 2, ProductId = 4, Quantity = 2, UnitPrice = 2 }, new OrderItem() { Id = 10, OrderId = 2, ProductId = 2, Quantity = 5, UnitPrice = 12 } } });
                dbContext.Orders.Add(new Order() { Id = 3, OrderDate = DateTime.Now, Total = 2, CustomerId = 1, Items = new List<OrderItem>() { new OrderItem() { Id = 7, OrderId = 3, ProductId = 5, Quantity = 2, UnitPrice = 2 }, new OrderItem() { Id = 11, OrderId = 3, ProductId = 2, Quantity = 5, UnitPrice = 13 } } });
                dbContext.Orders.Add(new Order() { Id = 4, OrderDate = DateTime.Now, Total = 24, CustomerId = 3, Items = new List<OrderItem>() { new OrderItem() { Id = 8, OrderId = 4, ProductId = 6, Quantity = 2, UnitPrice = 2 }, new OrderItem() { Id = 12, OrderId = 4, ProductId = 2, Quantity = 5, UnitPrice = 124 } } });
                dbContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, List<Models.Order> Orders, string ErrorMessage)> GetOrdersAsync(int customerId)
        {
            try
            {
                var result = await dbContext.Orders
                        .Where(Order => Order.CustomerId == customerId)
                        .Include(Order => Order.Items)
                        .ToListAsync();

                if (result != null && result.Any())
                {
                    
                    return (true, mapper.Map<List<Db.Order>, List<Models.Order>>(result), null);
                }

                return (false, null, "not found");

            }
            catch (Exception e)
            {
                logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
