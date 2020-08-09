using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.API.Orders.Interfaces
{
    public interface IOrdersProvider
    {
        Task<(bool IsSuccess, List<Models.Order> Orders, string ErrorMessage)> GetOrdersAsync(int customerId);
    }
}
