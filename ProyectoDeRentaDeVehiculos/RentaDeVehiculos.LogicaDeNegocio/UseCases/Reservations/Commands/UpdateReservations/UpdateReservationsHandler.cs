using Mapster;
using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Rentals.Commands.UpdateRentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Reservations.Commands.UpdateReservations;

internal sealed class UpdateReservationsHandler(IEfRepositorio<Reservation> _repository)
    : IRequestHandler<UpdateReservationsCommand, int>
{
    public async Task<int> Handle(UpdateReservationsCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var existingReservation = await _repository.GetByIdAsync(command.Request.Id);
            if (existingReservation is null) return 0;

            // 🔹 Aseguramos que no cambia el tipo de existingCustomer
            existingReservation = command.Request.Adapt(existingReservation);

            await _repository.UpdateAsync(existingReservation, cancellationToken);
            return existingReservation.Id;
        }
        catch (Exception)
        {
            return 0;
        }

    }

}

