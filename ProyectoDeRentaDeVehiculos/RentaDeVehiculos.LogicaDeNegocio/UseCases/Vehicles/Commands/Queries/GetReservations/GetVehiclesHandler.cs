using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.Queries.GetCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Vehicles.Commands.Queries.GetVehicles;

internal sealed class GetVehiclesHandler(IEfRepositorio<Vehicle> _repository)
   : IRequestHandler<GetVehicleQuery, List<VehicleResponse>>
{
    public async Task<List<VehicleResponse>> Handle(GetVehicleQuery query, CancellationToken cancellationToken)
    {

        var Vehicle = await _repository.ListAsync(cancellationToken);
        if (Vehicle == null || !Vehicle.Any())
        {

            return new List<VehicleResponse>();
        }

        // 🔹 Aseguramos que no cambia el tipo de existingCustomer

        return Vehicle.Adapt<List<VehicleResponse>>();
    }


}

