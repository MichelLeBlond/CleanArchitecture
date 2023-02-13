using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.AppointmentLists.Commands.CreateAppointmentList;

public record CreateAppointmentListCommand : IRequest<int>
{
    public string? Name { get; init; }
}

public class CreateAppoinmentListCommandHandler : IRequestHandler<CreateAppointmentListCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAppoinmentListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAppointmentListCommand request, CancellationToken cancellationToken)
    {
        var entity = new AppointmentList();

        entity.Name = request.Name;

        _context.AppointmentLists.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
