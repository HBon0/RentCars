using MediatR;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.Queries.GetRoles
{
    public record GetRolesQuery : IRequest<List<RoleResponse>>;
}
