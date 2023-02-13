using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.AppointmentLists.Commands.CreateAppointmentList;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.AppointmentLists.Commands.CreateAppointmentList;

public class CreateAppointmentListCommandValidator : AbstractValidator<CreateAppointmentListCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateAppointmentListCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
    }

    public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
    {
        return await _context.TodoLists
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}

