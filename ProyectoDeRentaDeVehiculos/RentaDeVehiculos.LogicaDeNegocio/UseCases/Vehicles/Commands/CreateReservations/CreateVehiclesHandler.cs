using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.CreateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Vehicles.Commands.CreateVehicles;

internal sealed class CreateVehiclesHandler(IEfRepositorio<Vehicle> _repository)
: IRequestHandler<CreateVehicleCommand, int>
{
    public async Task<int> Handle(CreateVehicleCommand command, CancellationToken cancellationToken)
    {
        try
        {

            var newVehicle = command.Request.Adapt<Vehicle>();
            var createVehicle = await _repository.AddAsync(newVehicle, cancellationToken);
            return createVehicle.Id;
        }
        catch (Exception)
        {
            return 0;
            throw;
        }
    }
}

