using AutoMapper;
using MediatR;
using Senac.StockManagement.Domain.Interfaces.Repositories;

namespace Senac.StockManagement.Application.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handle the GetProductById query to retrieve a specific product from the repository and return it as a response DTO.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new Exception($"Produto com ID {request.Id} não encontrado");
            }
            
            return _mapper.Map<GetProductByIdQueryResponse>(product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"Erro ao buscar produto com ID {request.Id}");
        }
    }
}
