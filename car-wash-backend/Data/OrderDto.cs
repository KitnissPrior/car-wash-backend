namespace car_wash_backend.Dto;

public class OrderDto
{
    public DateOnly DateTime { get; set; }

    public string? LicencePlate { get; set; }

    public long? BoxId { get; set; }

    public Guid OrderId { get; set; }

    public Guid CarwashId { get; set; }

    public Guid? StatusId { get; set; }

    public Guid UserId { get; set; }
    
    public virtual ICollection<Guid>? ServicesIds { get; set; } = new List<Guid>();
    
}