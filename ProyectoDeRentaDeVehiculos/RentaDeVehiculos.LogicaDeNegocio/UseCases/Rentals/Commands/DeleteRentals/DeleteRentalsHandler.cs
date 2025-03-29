using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.UpdateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Rentals.Commands.DeleteRentals;

internal sealed class DeleteRentalHandler(IEfRepositorio<Rental> _repository)
    : IRequestHandler<DeleteRentalsCommand, int>
{
    public async Task<int> Handle(DeleteRentalsCommand command, CancellationToken cancellationToken)
    {

        {
            var existingRental = await _repository.GetByIdAsync(command.RentalId);
            if (existingRental is null) return 0;

            // 🔹 Aseguramos que no cambia el tipo de existingCustomer

            await _repository.DeleteAsync(existingRental, cancellationToken);
            return existingRental.Id;
        }


    }

}




