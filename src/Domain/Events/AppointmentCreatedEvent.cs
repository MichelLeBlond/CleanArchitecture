namespace CleanArchitecture.Domain.Events;

public class AppointmentCreatedEvent : BaseEvent
{
    public AppointmentCreatedEvent(Appointment appointment)
    {
        Appointment = appointment;
    }

    public Appointment Appointment { get; }
}
