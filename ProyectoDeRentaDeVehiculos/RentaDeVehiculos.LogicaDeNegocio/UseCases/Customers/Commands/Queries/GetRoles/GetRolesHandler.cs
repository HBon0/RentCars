using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using MediatR;
using Mapster;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.Queries.GetRoles;

internal sealed class GetRolesHandler(IEfRepositorio<Role> _repository)
    : IRequestHandler<GetRolesQuery, List<RoleResponse>>
{
    public async Task<List<RoleResponse>> Handle(GetRolesQuery query, CancellationToken cancellationToken)
    {
        var roles = await _repository.ListAsync(cancellationToken);
        if (roles == null || !roles.Any())
        {
            return new List<RoleResponse>();
        }
        else
        {
            return roles.Adapt<List<RoleResponse>>();
        }
    }
}