using MediatR;

namespace Senac.StockManagement.Application.Queries.GetProductById;

public class GetProductByIdQueryRequest : IRequest<GetProductByIdQueryResponse>
{
    public int Id { get; set; }
}
