using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Entity
{
    public class OutBox
    {
        public int Id { get; set; }
        public Guid ModuleId { get; set; }
        public string TypeOfEvent { get; set; } = String.Empty;
        public string Content { get; set; } = String.Empty;
        public DateTime OccuranceOnDate { get; set; }
        public DateTime? ProcessedOnDate { get; set; }
        public string? Errors { get; set; } = String.Empty;
    }
}
