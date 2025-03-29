using MediatR;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Employees.Commands.Queries.GetRoles;

public record GetRolesQuery : IRequest<List<RoleResponse>>;
