namespace CleanArchitecture.Domain.Events;
public class AppointmentDeletedEvent : BaseEvent
{
    public AppointmentDeletedEvent(Appointment appointment)
    {
        Appointment = appointment;
    }

    public Appointment Appointment { get; }
}
