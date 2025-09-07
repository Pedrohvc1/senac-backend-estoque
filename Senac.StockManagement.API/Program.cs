using Asp.Versioning.ApiExplorer;
using Senac.StockManagement.API.SwaggerConfig;
using Senac.StockManagement.Application.Commands.CreateProduct;
using Senac.StockManagement.Application.Commands.UpdateProduct;
using Senac.StockManagement.Application.Queries.GetAllProducts;
using Senac.StockManagement.Application.Queries.GetProductById;
using Senac.StockManagement.Domain.Interfaces.Repositories;
using Senac.StockManagement.Infrastructure.Context;
using Senac.StockManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Senac.StockManagement.Application.Commands.Login;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

// Configuração do MediatR
builder.Services.AddMediatR(AppDomain.CurrentDomain.Load("Senac.StockManagement.Application"));

// Configuração do AutoMapper
builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddApiVersioning()
    .AddMvc()
    .AddApiExplorer(setup =>
    {
        setup.GroupNameFormat = "'v'VVV";
        setup.SubstituteApiVersionInUrl = true;
    });

builder.Services.ConfigureOptions<SwaggerDefaultValues.ConfigureSwaggerGenOptions>();
builder.Services.AddHttpClient();

// Adiciona o DbContext do StockService usando PostgreSQL
builder.Services.AddDbContext<StockDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL_Estudos_Local")));

// Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Handlers
builder.Services.AddScoped<IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>, CreateProductCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>, UpdateProductCommandHandler>();
builder.Services.AddScoped<IRequestHandler<GetAllProductsQueryRequest, IEnumerable<GetAllProductsQueryResponse>>, GetAllProductsQueryHandler>();
builder.Services.AddScoped<IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>, GetProductByIdQueryHandler>();

builder.Services.AddScoped<IRequestHandler<LoginCommandRequest, LoginCommandResponse>, LoginCommandHandler>();
var app = builder.Build();
    
app.MapOpenApi();
app.UseHttpsRedirection();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    var version = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    foreach (var description in version.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"Stock Management Api - {description.GroupName.ToUpper()}");
    }
});

app.Run();