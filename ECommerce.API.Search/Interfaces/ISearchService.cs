using System;
using System.Threading.Tasks;
using ECommerce.API.Search.Models;

namespace ECommerce.API.Search.Interfaces
{
    public interface ISearchService
    {
        Task<(bool IsSuccess, dynamic SearchResult)> SearchAsync(SearchTerm term);
    }
}
