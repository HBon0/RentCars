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

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Reservations.Commands.Queries.GetReservations;

internal sealed class GetReservationsHandler(IEfRepositorio<Reservation> _repository)
    : IRequestHandler<GetReservationsQuery, List<ReservationResponse>>
{
    public async Task<List<ReservationResponse>> Handle(GetReservationsQuery query, CancellationToken cancellationToken)
    {

        var Reservation = await _repository.ListAsync(cancellationToken);
        if (Reservation == null || !Reservation.Any())
        {

            return new List<ReservationResponse>();
        }

        // 🔹 Aseguramos que no cambia el tipo de existingCustomer

        return Reservation.Adapt<List<ReservationResponse>>();
    }


}
