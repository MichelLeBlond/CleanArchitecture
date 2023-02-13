using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Security;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.AppointmentLists.Queries.GetAppointments;

[Authorize]
public record GetAppointmentsQuery : IRequest<AppointmentsVm>;

public class GetAppointmentsQueryHandler : IRequestHandler<GetAppointmentsQuery, AppointmentsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAppointmentsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AppointmentsVm> Handle(GetAppointmentsQuery request, CancellationToken cancellationToken)
    {
        return new AppointmentsVm
        {
            PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                .Cast<PriorityLevel>()
                .Select(p => new PriorityLevelDto { Value = (int)p, Name = p.ToString() })
                .ToList(),

            Lists = await _context.AppointmentLists
                .AsNoTracking()
                .ProjectTo<AppointmentListDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Name)
                .ToListAsync(cancellationToken)
        };
    }
}
