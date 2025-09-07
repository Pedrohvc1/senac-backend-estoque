using AutoMapper;
using Senac.StockManagement.Application.Commands.CreateProduct;
using Senac.StockManagement.Application.Commands.Login;
using Senac.StockManagement.Application.Commands.RegisterUser;
using Senac.StockManagement.Application.Commands.UpdateProduct;
using Senac.StockManagement.Application.Queries.GetAllProducts;
using Senac.StockManagement.Application.Queries.GetProductById;
using Senac.StockManagement.Domain.Entities;

namespace Senac.StockManagement.Application.Mapper;

public class ProfileAutomapper : Profile
{
    public ProfileAutomapper()
    {
        // CreateProduct mappings
        CreateMap<CreateProductCommandRequest, Product>();
        CreateMap<Product, CreateProductCommandResponse>();

        // UpdateProduct mappings
        CreateMap<UpdateProductCommandRequest, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        CreateMap<Product, UpdateProductCommandResponse>();

        // GetAllProducts mappings
        CreateMap<Product, GetAllProductsQueryResponse>();

        // GetProductById mappings
        CreateMap<Product, GetProductByIdQueryResponse>();
        
        // Login mappings
        CreateMap<LoginCommandRequest, LoginCommandResponse>();
        
        // RegisterUser mappings
        CreateMap<RegisterUserCommandRequest, User>();
        CreateMap<User, RegisterUserCommandResponse>();
    }
}