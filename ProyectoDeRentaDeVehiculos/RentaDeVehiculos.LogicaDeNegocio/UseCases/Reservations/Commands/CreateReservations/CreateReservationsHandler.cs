using Mapster;
using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Rentals.Commands.CreateRentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Reservations.Commands.CreateReservations;

internal sealed class CreateReservationsHandler(IEfRepositorio<Reservation> _repository)
: IRequestHandler<CreateReservationsCommand, int>
{
    public async Task<int> Handle(CreateReservationsCommand command, CancellationToken cancellationToken)
    {
        try
        {

            var newReservation = command.Request.Adapt<Reservation>();
            var createReservation = await _repository.AddAsync(newReservation, cancellationToken);
            return createReservation.Id;
        }
        catch (Exception)
        {
            return 0;
            throw;
        }
    }
}

