﻿using MasterTables.Application.Commands;
using MasterTables.Domain.Interfaces;
using MediatR;

namespace MasterTables.Application.CommandHandlers
{
    public class DeleteVendorCommandHandler : IRequestHandler<DeleteVendorCommand, bool>
    {
        private readonly IVendorRepository _repository;

        public DeleteVendorCommandHandler(IVendorRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteVendorCommand request, CancellationToken cancellationToken = default)
        {
            var vendor = await _repository.GetVendorByIdAsync(request.Id, cancellationToken);
            if (vendor == null)
            {
                throw new Exception("Vendor not found");
            }

            await _repository.DeleteVendorAsync(vendor, cancellationToken);
            return true;
        }
    }
}
