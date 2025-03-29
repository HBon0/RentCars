using MediatR;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Reservations.Commands.Queries.GetReservations;

public record GetReservationsQuery() : IRequest<List<ReservationResponse>>;
