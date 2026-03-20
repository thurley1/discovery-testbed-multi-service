namespace OrderService.Domain;

public enum OrderStatus
{
    Draft,
    Submitted,
    Confirmed,
    Shipped,
    Delivered,
    Cancelled
}
