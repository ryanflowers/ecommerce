using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.API.Search.Models;

namespace ECommerce.API.Search.Interfaces
{
    public interface IOrdersService
    {
        Task<(bool IsSuccess, IEnumerable<Order>Orders, string message)> GetOrdersAsync(int customerId);
    }
}
