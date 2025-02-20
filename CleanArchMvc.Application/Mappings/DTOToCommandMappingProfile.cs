﻿using AutoMapper;
using CleanArchMvc.Application.Products.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {

        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductCreateCommand, DTOs.ProductDTO>().ReverseMap();
            CreateMap<ProductUpdateCommand, DTOs.ProductDTO>().ReverseMap();
        }
    }
}
