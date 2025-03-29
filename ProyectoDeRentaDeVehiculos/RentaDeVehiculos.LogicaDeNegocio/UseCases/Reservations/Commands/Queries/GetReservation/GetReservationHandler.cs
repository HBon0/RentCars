using Mapster;
using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Rentals.Commands.Queries.GetRentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Reservations.Commands.Queries.GetReservation;

internal sealed class GetReservationHandler(IEfRepositorio<Reservation> _repository)
    : IRequestHandler<GetReservationQuery, ReservationResponse>
{
    public async Task<ReservationResponse> Handle(GetReservationQuery query, CancellationToken cancellationToken)
    {

        var Reservation = await _repository.GetByIdAsync(query.ReservationId, cancellationToken);
        if (Reservation is null)
        {

            return new ReservationResponse();
        }

        // 🔹 Aseguramos que no cambia el tipo de existingCustomer

        return Reservation.Adapt<ReservationResponse>();
    }

}


