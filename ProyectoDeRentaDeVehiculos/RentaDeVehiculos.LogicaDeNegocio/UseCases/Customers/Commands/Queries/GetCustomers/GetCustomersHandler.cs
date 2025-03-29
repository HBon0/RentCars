using Mapster;
using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.DeleteCustomer;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.Queries.GetCustomer;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.UpdateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.Queries.GetCustomers;
 internal sealed class GetCustomersHandler(IEfRepositorio<Customer> _repository)
   : IRequestHandler<GetCustomersQuery, List<CustomerResponse>>
{
    public async Task<List<CustomerResponse>> Handle(GetCustomersQuery query, CancellationToken cancellationToken)
    {
        
            var Customer = await _repository.ListAsync(cancellationToken);
            if (Customer == null || !Customer.Any())
            {

                return new List<CustomerResponse>(); }

            // 🔹 Aseguramos que no cambia el tipo de existingCustomer

            return Customer.Adapt<List<CustomerResponse>>();
        }

   
}
