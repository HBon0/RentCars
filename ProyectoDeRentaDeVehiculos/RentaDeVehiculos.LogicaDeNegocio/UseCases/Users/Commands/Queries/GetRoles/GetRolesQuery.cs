using MediatR;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using System.Collections.Generic;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Queries.GetRoles
{
    public class GetRolesQuery : IRequest<List<RoleDto>>
    {
    }
}
