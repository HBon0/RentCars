using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.UpdateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Vehicles.Commands.UpdateVehicle;


internal sealed class UpdateVehicleHandler(IEfRepositorio<Vehicle> _repository)
    : IRequestHandler<UpdateVehiclesCommand, int>
{
    public async Task<int> Handle(UpdateVehiclesCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var existingVehicle = await _repository.GetByIdAsync(command.Request.Id);
            if (existingVehicle is null) return 0;

            // 🔹 Aseguramos que no cambia el tipo de existingCustomer
            existingVehicle = command.Request.Adapt(existingVehicle);

            await _repository.UpdateAsync(existingVehicle, cancellationToken);
            return existingVehicle.Id;
        }
        catch (Exception)
        {
            return 0;
        }

    }

}
