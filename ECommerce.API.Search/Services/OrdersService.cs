using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ECommerce.API.Search.Interfaces;
using ECommerce.API.Search.Models;
using Microsoft.Extensions.Logging;

namespace ECommerce.API.Search.Services
{
    public class OrdersService : IOrdersService
    {
        private IHttpClientFactory clientFactory;
        private ILogger<OrdersService> loggerFactory;

        public OrdersService(IHttpClientFactory clientFactory, ILogger<OrdersService> loggerFactory)
        {
            this.clientFactory = clientFactory;
            this.loggerFactory = loggerFactory;
        }

        public async Task<(bool IsSuccess, IEnumerable<Order> Orders, string message)> GetOrdersAsync(int customerId)
        {
           try {
                var client = this.clientFactory.CreateClient("OrdersService");
                var response = await client.GetAsync($"api/orders/{customerId}");

                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<Order>>(content, options);
                    return (true, result, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch(Exception ex)
            {
                return(false, null, ex.Message);
               
            }
        }
    }
}
