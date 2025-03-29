using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using MediatR;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.Queries.GetCustomersAuthenticated;

internal sealed class GetCustomersAuthenticatedHandler(IEfRepositorio<User> _repository)
    : IRequestHandler<GetCustomersAuthenticatedQuery, CustomerResponse>
{
    public Task<CustomerResponse> Handle(GetCustomersAuthenticatedQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
