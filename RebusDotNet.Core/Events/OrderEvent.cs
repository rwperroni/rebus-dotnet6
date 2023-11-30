namespace RebusDotNet.Core.Events;

public class OrderEvent
{
    public int OrderId { get; set; }
    public int Amount { get; set; }
    public int ProductId { get; set; }
}
