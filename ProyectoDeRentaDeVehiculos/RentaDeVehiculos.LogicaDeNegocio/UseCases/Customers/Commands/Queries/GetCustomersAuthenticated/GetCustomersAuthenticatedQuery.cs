using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using MediatR;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.Queries.GetCustomersAuthenticated;
public record GetCustomersAuthenticatedQuery (string UserName, string Password)
    : IRequest<CustomerResponse>;
