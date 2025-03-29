using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaDeVehiculos.Entidades;
using Mapster;


namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.CreateCustomer;

internal sealed class CreateCustomerHandler(IEfRepositorio<Customer> _repository)
: IRequestHandler<CreateCustomerCommand, int>
{
    public async Task<int> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        try
        {

            var newCustomer = command.Request.Adapt<Customer>();
            var createCustomer = await _repository.AddAsync(newCustomer, cancellationToken);
            return createCustomer.Id;
        }
        catch (Exception){
            return 0;
            throw;
        }
    }
}
