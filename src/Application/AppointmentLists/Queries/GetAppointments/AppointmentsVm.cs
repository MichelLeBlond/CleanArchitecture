using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.AppointmentLists.Queries.GetAppointments;

namespace CleanArchitecture.Application.AppointmentLists.Queries.GetAppointments;
public class AppointmentsVm
{
    public IList<PriorityLevelDto> PriorityLevels { get; set; } = new List<PriorityLevelDto>();

    public IList<AppointmentListDto> Lists { get; set; } = new List<AppointmentListDto>();
}
