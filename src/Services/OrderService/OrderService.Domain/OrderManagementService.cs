using PlatformServices.Common;

namespace OrderService.Domain;

public class OrderManagementService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEventBus _eventBus;

    public OrderManagementService(IOrderRepository orderRepository, IEventBus eventBus)
    {
        _orderRepository = orderRepository;
        _eventBus = eventBus;
    }

    public async Task<Result<Order>> CreateOrderAsync(
        Guid customerId,
        CancellationToken cancellationToken = default)
    {
        var order = Order.Create(customerId);
        await _orderRepository.AddAsync(order, cancellationToken);
        return Result.Success(order);
    }

    public async Task<Result> SubmitOrderAsync(
        Guid orderId,
        CancellationToken cancellationToken = default)
    {
        var order = await _orderRepository.GetByIdAsync(orderId, cancellationToken);
        if (order is null)
            return Result.Failure("Order not found");

        order.Submit();
        await _orderRepository.UpdateAsync(order, cancellationToken);
        return Result.Success();
    }
}
