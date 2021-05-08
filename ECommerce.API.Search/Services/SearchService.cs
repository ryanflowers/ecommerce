using System;
using System.Threading.Tasks;
using ECommerce.API.Search.Interfaces;
using ECommerce.API.Search.Models;

namespace ECommerce.API.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IOrdersService ordersService;

        public SearchService(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public async Task<(bool IsSuccess, dynamic SearchResult)> SearchAsync(SearchTerm term)
        {
            var ordersResult = await this.ordersService.GetOrdersAsync(term.CustomerId);
            if(ordersResult.IsSuccess)
            {
                var result = new
                {
                    ordersResult.Orders
                };

                return (true, result);            }
            return (false, null);   }
    }
}
