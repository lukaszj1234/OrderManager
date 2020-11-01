using AutoMapper;
using OrderManager.DataAccess.Models;
using OrderManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManager.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDetailViewModel>();
        }
    }
}
