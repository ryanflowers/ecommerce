using System;
using System.Collections.Generic;

namespace ECommerce.API.Orders.Profiles
{
    public class OrderProfiles: AutoMapper.Profile
    {
        public OrderProfiles()
        {

            CreateMap<Db.OrderItem, Models.OrderItem>();
            CreateMap<Db.Order, Models.Order>();
        }
    }
}
