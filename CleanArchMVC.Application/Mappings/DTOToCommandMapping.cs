using System;
using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Products.Commands;

namespace CleanArchMVC.Application.Mappings
{
    public class DTOToCommandMapping : Profile
    {
        public DTOToCommandMapping()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}