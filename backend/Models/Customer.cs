namespace ContactBook.Api.Models;

public class Customer
{
    public int Id { get; set; }                      // 🔁 was CustomerId
    public string FirstName { get; set; } = default!;
    public string LastName  { get; set; } = default!;
    public string? Phone    { get; set; }
    public string? Street   { get; set; }
    public string? City     { get; set; }
    public string? State    { get; set; }
    public string? Zip      { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public ICollection<Order>? Orders { get; set; }
}

/*
public class Customer
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName  { get; set; } = default!;
    public string? Email    { get; set; }
    public string? Phone    { get; set; }
    public ICollection<Order>? Orders { get; set; }
}
*/