using AutoMapper;
using MediatR;
using Senac.StockManagement.Domain.Entities;
using Senac.StockManagement.Domain.Interfaces.Repositories;

namespace Senac.StockManagement.Application.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handle the CreateProduct command to add a new product to the repository and return the created product as a response DTO.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest command,
        CancellationToken cancellationToken)
    {
        try
        {
            var product = _mapper.Map<Product>(command);
            product.CreatedAt = DateTime.Now;
            
            await _productRepository.AddAsync(product);
            var result = _mapper.Map<CreateProductCommandResponse>(product);
            return new CreateProductCommandResponse(true, "Produto cadastrado com sucesso.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro no cadastro do produto {command.Name}: {e.Message}");
            Console.WriteLine($"Stack trace: {e.StackTrace}");
            throw; // Re-lança a exceção original em vez de criar uma nova
        }
    }
}