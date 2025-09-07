using AutoMapper;
using MediatR;
using Senac.StockManagement.Domain.Interfaces.Repositories;

namespace Senac.StockManagement.Application.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IEnumerable<GetAllProductsQueryResponse>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handle the GetAllProducts query to retrieve all products from the repository and return them as response DTOs.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetAllProductsQueryResponse>>(products);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("Erro ao buscar todos os produtos");
        }
    }
}
