namespace OrderService.WebApi;

public sealed record CreateOrderRequest(Guid CustomerId, List<OrderItemDto> Items);

public sealed record OrderItemDto(string ProductName, int Quantity, decimal UnitPrice);
