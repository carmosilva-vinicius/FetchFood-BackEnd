using AutoMapper;
using FetchFood.Entities;
using FetchFood.UseCases.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchFood.UseCases.Profiles
{
    internal class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ReadItemDto>();
            CreateMap<UpdateItemDto, Item>();
            CreateMap<CreateItemDto, Item>();
        }
    }
}
