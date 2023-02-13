using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;


namespace CleanArchitecture.Application.AppointmentLists.Queries.GetAppointments;
public class AppointmentListDto : IMapFrom<AppointmentList>
{
    public AppointmentListDto()
    {
        Items = new List<AppointmentDto>();
    }


    public int Id { get; set; }

    public string? Name { get; set; }

    public IList<AppointmentDto> Items { get; set; }
}
