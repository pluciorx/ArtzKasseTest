using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs.Entities
{
    public class Drug
    {
        public int DrugId { get; set; }
        public int TenantId { get; set; }
        public string DrugCode { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
