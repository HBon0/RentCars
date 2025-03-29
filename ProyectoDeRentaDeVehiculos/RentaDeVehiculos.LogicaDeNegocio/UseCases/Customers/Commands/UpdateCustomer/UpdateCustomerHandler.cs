using Mapster;
using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;



namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.UpdateCustomer;

internal sealed class UpdateCustomerHandler(IEfRepositorio<Customer> _repository)
    : IRequestHandler<UpdateCustomerCommand, int>
{
    public async Task<int> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var existingCustomer = await _repository.GetByIdAsync(command.Request.Id);
            if (existingCustomer is null) return 0;

            // 🔹 Aseguramos que no cambia el tipo de existingCustomer
            existingCustomer=command.Request.Adapt(existingCustomer);

            await _repository.UpdateAsync(existingCustomer, cancellationToken);
            return existingCustomer.Id; 
        }
        catch (Exception )
        {
            return 0;
        }

    }

}
