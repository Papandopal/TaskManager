using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Project
    {
        public Guid Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public Guid OwnerId { get; set; }
        public ProjectStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
