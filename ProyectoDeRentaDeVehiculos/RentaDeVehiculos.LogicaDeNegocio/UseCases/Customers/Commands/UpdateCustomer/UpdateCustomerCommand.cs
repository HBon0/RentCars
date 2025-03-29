using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.UpdateCustomer
{


    public record UpdateCustomerCommand(UpdateCustomerRequest Request) : IRequest<int>
    {
    }
}
