namespace ContactBook.Api.Models;

public class Order
{
    public int Id { get; set; }                    // ← was OrderId
    public int CustomerId { get; set; }
    public DateTime CreatedAt { get; set; }        // ← was Date
}

/*public class Order
{
    public int OrderId     { get; set; }
    public DateTime Date   { get; set; }
    public decimal Total   { get; set; }
    public int CustomerId  { get; set; }
}*/
