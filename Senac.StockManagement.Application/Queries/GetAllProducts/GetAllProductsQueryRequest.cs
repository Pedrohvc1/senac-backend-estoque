using MediatR;

namespace Senac.StockManagement.Application.Queries.GetAllProducts;

public class GetAllProductsQueryRequest : IRequest<IEnumerable<GetAllProductsQueryResponse>>
{
}
