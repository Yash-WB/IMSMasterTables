﻿namespace MasterTables.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid CreatedBy { get; set; } = Guid.NewGuid();
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; } = Guid.NewGuid();
        public bool IsActive { get; set; } = false;
    }

}
