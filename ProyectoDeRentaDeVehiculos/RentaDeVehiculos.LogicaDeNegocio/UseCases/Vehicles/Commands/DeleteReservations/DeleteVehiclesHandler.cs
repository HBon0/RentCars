using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.DeleteCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Vehicles.Commands.DeleteVehicles;

internal sealed class DeleteVehicleHandler(IEfRepositorio<Vehicle> _repository)
    : IRequestHandler<DeleteVehicleCommand, int>
{
    public async Task<int> Handle(DeleteVehicleCommand command, CancellationToken cancellationToken)
    {

        {
            var existingVehicle= await _repository.GetByIdAsync(command.VehicleId);
            if (existingVehicle is null) return 0;

            // 🔹 Aseguramos que no cambia el tipo de existingCustomer

            await _repository.DeleteAsync(existingVehicle, cancellationToken);
            return existingVehicle.Id;
        }


    }

}
