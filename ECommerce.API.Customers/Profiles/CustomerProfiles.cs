using System;
namespace ECommerce.API.Products.Profiles
{
    public class ProductProfiles: AutoMapper.Profile
    {
        public ProductProfiles()
        {
            CreateMap<Customers.Db.Customer, Customers.Models.Customer>();
        }
    }
}
