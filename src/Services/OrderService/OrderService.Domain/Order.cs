namespace OrderService.Domain;

public class Order
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public OrderStatus Status { get; private set; }
    public decimal TotalAmount { get; private set; }
    public DateTime CreatedAt { get; private set; }
    private readonly List<OrderItem> _items = [];
    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();

    private Order() { }

    public static Order Create(Guid customerId)
    {
        return new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            Status = OrderStatus.Draft,
            TotalAmount = 0m,
            CreatedAt = DateTime.UtcNow
        };
    }

    public void AddItem(string productName, int quantity, decimal unitPrice)
    {
        var item = OrderItem.Create(Id, productName, quantity, unitPrice);
        _items.Add(item);
        TotalAmount = _items.Sum(i => i.LineTotal);
    }

    public void Submit()
    {
        if (Status != OrderStatus.Draft)
            throw new InvalidOperationException("Only draft orders can be submitted.");
        if (_items.Count == 0)
            throw new InvalidOperationException("Cannot submit an empty order.");
        Status = OrderStatus.Submitted;
    }

    public void Cancel()
    {
        if (Status == OrderStatus.Shipped)
            throw new InvalidOperationException("Shipped orders cannot be cancelled.");
        Status = OrderStatus.Cancelled;
    }
}
