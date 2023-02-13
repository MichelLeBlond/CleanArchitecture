using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class AppointmentList : BaseAuditableEntity
{
    public string? Name { get;set; }
    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}
