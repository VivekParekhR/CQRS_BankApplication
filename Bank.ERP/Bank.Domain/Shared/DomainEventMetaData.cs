using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Shared
{
    public class DomainEventMetaData
    {
        public int Id { get; set; }
        public Guid ModuleId { get; set; }
        public string TypeOfEvent { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime OccuranceOnDate { get; set; }
        public DateTime? ProcessedOnDate { get; set; }
        public string? Errors { get; set; } = string.Empty;
    }
}
