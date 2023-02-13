using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<AppointmentList> AppointmentLists { get; }  
    
    DbSet<Appointment> AppointmentItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
