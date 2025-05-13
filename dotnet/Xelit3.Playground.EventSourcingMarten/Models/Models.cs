namespace Xelit3.Playground.EventSourcingMarten.Models;


public abstract record Event
{
    public Guid EventId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}


public enum AppointmentStatus
{
    Created,
    Confirmed,
    Cancelled
}


public record AppointmentCreationRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
}

public record AppointmentCreated : Event
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Created;
    public string Title { get; set; }
    public string Description { get; set; }
}

public record AppointmentStatusChanged : Event
{
    public Guid Id { get; set; }
    public AppointmentStatus StatusUpdated { get; set; }
}

public record AppointmentUpdated : Event
{
    public Guid Id { get; set; }
    public string DescriptionUpdated { get; set; }
}



public class Appointment
{

    public Guid Id { get; set; } = Guid.CreateVersion7();
    public AppointmentStatus Status { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    public Appointment() { }

    public Appointment(AppointmentStatus status, string title, string description)
    {
        Status = status;
        Title = title;
        Description = description;
    }


    /// <summary>
    /// Apply the AppointmentCreated event to the current appointment. This is done under demand and not through a persisted projection
    /// </summary>
    /// <param name="appointmentCreated"></param>
    public void Apply(AppointmentCreated appointmentCreated) 
    {
        Id = appointmentCreated.Id;
        Status = appointmentCreated.Status;
        Title = appointmentCreated.Title;
        Description = appointmentCreated.Description;
    }
}