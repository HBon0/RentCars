using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaDeVehiculos.Entidades;
using Mapster;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Rentals.Commands.CreateRentals;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Rentals.Commands.CreateRentals;

internal sealed class CreateRentalsHandler(IEfRepositorio<Rental> _repository)
: IRequestHandler<CreateRentalsCommand, int>
{
    public async Task<int> Handle(CreateRentalsCommand command, CancellationToken cancellationToken)
    {
        try
        {

            var newRental = command.Request.Adapt<Rental>();
            var createRental = await _repository.AddAsync(newRental, cancellationToken);
            return createRental.Id;
        }
        catch (Exception)
        {
            return 0;
            throw;
        }
    }
}
