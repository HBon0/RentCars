using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Vehicles.Commands.Queries.GetVehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Vehicles.Commands.Queries.GetVehicle;


internal sealed class GetVehicleHandler(IEfRepositorio<Vehicle> _repository)
    : IRequestHandler<GetVehicleQuery, VehicleResponse>
{
    public async Task<VehicleResponse> Handle(GetVehicleQuery query, CancellationToken cancellationToken)
    {

        var Vehicle = await _repository.GetByIdAsync(query.VehicleId, cancellationToken);
        if (Vehicle is null )
        {

            return new VehicleResponse();
        }

        // 🔹 Aseguramos que no cambia el tipo de existingCustomer

        return Vehicle.Adapt<VehicleResponse>();
    }

}