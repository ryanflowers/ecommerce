using System;
using System.Threading.Tasks;
using ECommerce.API.Search.Interfaces;
using ECommerce.API.Search.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Search.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchSevice;

        public SearchController(ISearchService searchSevice)
        {
            this.searchSevice = searchSevice;
        }

        [HttpPost]
        public async Task<IActionResult> SearchAsync(SearchTerm searchTerm)
        {
            var result = await searchSevice.SearchAsync(searchTerm);

            if(result.IsSuccess)
            {
                return Ok(result.SearchResult);
            }

            return NotFound();
        }
    }
}
