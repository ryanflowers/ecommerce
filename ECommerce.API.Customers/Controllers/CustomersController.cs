﻿using System;
using System.Threading.Tasks;
using ECommerce.API.Customers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.customers.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController: ControllerBase
    {
        private readonly ICustomersProvider customersProvider;

        public CustomersController(ICustomersProvider customersProvider)
        {
            this.customersProvider = customersProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var result = await customersProvider.GetCustomersAsync();
            if(result.IsSuccess)
            {
                return Ok(result.Customers);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomersAsync(int id)
        {
            var result = await customersProvider.GetCustomerAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Customer);
            }

            return NotFound();
        }
    }
}
