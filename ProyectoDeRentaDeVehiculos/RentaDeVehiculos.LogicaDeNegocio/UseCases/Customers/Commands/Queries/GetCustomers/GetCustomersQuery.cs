using MediatR;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.Queries.GetCustomer;

public record GetCustomersQuery(): IRequest<List<CustomerResponse>>;
