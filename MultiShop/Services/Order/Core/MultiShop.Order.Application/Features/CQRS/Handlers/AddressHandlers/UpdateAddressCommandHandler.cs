using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public UpdateAddressCommandHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var value = await _addressRepository.GetByIdAsync(updateAddressCommand.AddressId);
            value.City = updateAddressCommand.City;
            value.Detail1 = updateAddressCommand.Detail1;
            value.District = updateAddressCommand.District;
            value.UserId = updateAddressCommand.UserId;
            await _addressRepository.UpdateAsync(value);
        }
    }
}
