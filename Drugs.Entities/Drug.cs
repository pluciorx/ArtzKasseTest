using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using System.Text;

namespace Drugs.Entities
{
    [Table("Drugs")]
    public class Drug
    {
        [Key]
        public int DrugId { get; set; }
        public int TenantId { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
