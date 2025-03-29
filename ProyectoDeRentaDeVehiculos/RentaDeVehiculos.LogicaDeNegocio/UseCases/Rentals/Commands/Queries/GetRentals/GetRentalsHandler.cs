using Mapster;
using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.DeleteCustomer;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.Queries.GetCustomer;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.UpdateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Rentals.Commands.Queries.GetRentals;
internal sealed class GetRentalHandler(IEfRepositorio<Rental> _repository)
    : IRequestHandler<GetRentalsQuery, List<RentalResponse>>
{
    public async Task<List<RentalResponse>> Handle(GetRentalsQuery query, CancellationToken cancellationToken)
    {

        var Rental = await _repository.ListAsync(cancellationToken);
        if (Rental == null || !Rental.Any())
        {

            return new List<RentalResponse>();
        }

        // 🔹 Aseguramos que no cambia el tipo de existingCustomer

        return Rental.Adapt<List<RentalResponse>>();
    }


}
