namespace Senac.StockManagement.Application.Commands.UpdateProduct;

public class UpdateProductCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;

    public UpdateProductCommandResponse()
    {
    }

    public UpdateProductCommandResponse(bool success, string message)
    {
        Success = success;
        Message = message;
    }
}
