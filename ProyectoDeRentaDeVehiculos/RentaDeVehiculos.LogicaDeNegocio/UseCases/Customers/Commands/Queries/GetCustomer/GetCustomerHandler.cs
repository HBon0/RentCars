using Mapster;
using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.Queries.GetCustomer;

internal sealed class GetCustomerHandler(IEfRepositorio<Customer> _repository)
    : IRequestHandler<GetCustomerQuery, CustomerResponse>
{
    public async Task<CustomerResponse> Handle(GetCustomerQuery query, CancellationToken cancellationToken)
    {

        var Customer = await _repository.GetByIdAsync(query.CustomerId, cancellationToken);
        if (Customer is null )
        {

            return new CustomerResponse();
        }

        // 🔹 Aseguramos que no cambia el tipo de existingCustomer

        return Customer.Adapt<CustomerResponse>();
    }

}

