using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Rentals.Commands.DeleteRentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Reservations.Commands.DeleteReservations;


internal sealed class DeleteReservationHandler(IEfRepositorio<Reservation> _repository)
    : IRequestHandler<DeleteReservationsCommand, int>
{
    public async Task<int> Handle(DeleteReservationsCommand command, CancellationToken cancellationToken)
    {

        {
            var existingReservation = await _repository.GetByIdAsync(command.ReservationId);
            if (existingReservation is null) return 0;

            // 🔹 Aseguramos que no cambia el tipo de existingCustomer

            await _repository.DeleteAsync(existingReservation, cancellationToken);
            return existingReservation.Id;
        }


    }

}

