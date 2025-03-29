using Mapster;
using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;



namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Rentals.Commands.UpdateRentals;

internal sealed class UpdateRentalsHandler(IEfRepositorio<Rental> _repository)
    : IRequestHandler<UpdateRentalsCommand, int>
{
    public async Task<int> Handle(UpdateRentalsCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var existingRental = await _repository.GetByIdAsync(command.Request.Id);
            if (existingRental is null) return 0;

            // 🔹 Aseguramos que no cambia el tipo de existingCustomer
            existingRental = command.Request.Adapt(existingRental);

            await _repository.UpdateAsync(existingRental, cancellationToken);
            return existingRental.Id;
        }
        catch (Exception)
        {
            return 0;
        }

    }

}
