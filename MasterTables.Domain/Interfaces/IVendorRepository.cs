﻿using MasterTables.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTables.Domain.Interfaces
{
    public interface IVendorRepository
    {
        Task<IEnumerable<Vendor>> GetAllVendorsAsync();
        Task<Vendor> GetVendorByIdAsync(Guid id);
        Task<Vendor> AddVendorAsync(Vendor Vendor);
        Task<Vendor> UpdateVendorAsync(Vendor Vendor);
        Task DeleteVendorAsync(Guid id);
    }
}
