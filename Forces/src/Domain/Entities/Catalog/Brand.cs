﻿using Forces.Domain.Contracts;

namespace Forces.Domain.Entities.Catalog
{
    public class Brand : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Tax { get; set; }
    }
}