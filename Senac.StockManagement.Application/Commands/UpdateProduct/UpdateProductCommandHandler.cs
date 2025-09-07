using AutoMapper;
using MediatR;
using Senac.StockManagement.Domain.Entities;
using Senac.StockManagement.Domain.Interfaces.Repositories;

namespace Senac.StockManagement.Application.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handle the UpdateProduct command to update an existing product in the repository and return the updated product as a response DTO.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest command,
        CancellationToken cancellationToken)
    {
        try
        {
            var existingProduct = await _productRepository.GetByIdAsync(command.Id);
            if (existingProduct == null)
            {
                return new UpdateProductCommandResponse(false, "Produto não encontrado.");
            }

            _mapper.Map(command, existingProduct);
            existingProduct.UpdatedAt = DateTime.Now;

            await _productRepository.UpdateAsync(existingProduct);
            return new UpdateProductCommandResponse(true, "Produto atualizado com sucesso.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro na atualização do produto {command.Name}: {e.Message}");
            Console.WriteLine($"Stack trace: {e.StackTrace}");
            Console.WriteLine($"Inner exception: {e.InnerException?.Message}");
            throw; // Re-lança a exceção original em vez de criar uma nova
        }
    }
}