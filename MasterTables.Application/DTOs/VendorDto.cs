﻿namespace MasterTables.Application.DTOs
{
    public class VendorDto
    {
        public Guid Id { get; set; }
        public string VendorName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string ContactPersonName { get; set; } = string.Empty;
        public string ContactPersonPhone { get; set; } = string.Empty;
    }

}
