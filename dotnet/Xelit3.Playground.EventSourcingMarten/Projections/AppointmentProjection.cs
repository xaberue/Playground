using Marten.Events.Aggregation;
using Xelit3.Playground.EventSourcingMarten.Models;

namespace Xelit3.Playground.EventSourcingMarten.Projections;

public class AppointmentProjection : SingleStreamProjection<Appointment>
{

    public void Apply(AppointmentCreated appointmentCreated, Appointment appointment)
    {
        appointment.Id = appointmentCreated.Id;
        appointment.Status = appointmentCreated.Status;
        appointment.Title = appointmentCreated.Title;
        appointment.Description = appointmentCreated.Description;
    }

    public void Apply(AppointmentStatusChanged appointmentStatusChanged, Appointment appointment)
    {
        appointment.Status = appointmentStatusChanged.StatusUpdated;
    }

    public void Apply(AppointmentUpdated appointmentUpdated, Appointment appointment)
    {
        appointment.Description = appointmentUpdated.DescriptionUpdated;
    }
}
