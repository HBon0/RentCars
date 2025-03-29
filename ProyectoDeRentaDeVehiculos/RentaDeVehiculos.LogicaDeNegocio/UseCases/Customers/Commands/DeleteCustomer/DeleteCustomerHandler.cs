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

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.DeleteCustomer;

internal sealed class DeleteCustomerHandler(IEfRepositorio<Customer> _repository)
    : IRequestHandler<DeleteCustomerCommand, int>
{
    public async Task<int> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
    {
        
        {
            var existingCustomer = await _repository.GetByIdAsync(command.CustomerId);
            if (existingCustomer is null) return 0;

            // 🔹 Aseguramos que no cambia el tipo de existingCustomer

            await _repository.DeleteAsync(existingCustomer, cancellationToken);
            return existingCustomer.Id;
        }
      

    }

}




