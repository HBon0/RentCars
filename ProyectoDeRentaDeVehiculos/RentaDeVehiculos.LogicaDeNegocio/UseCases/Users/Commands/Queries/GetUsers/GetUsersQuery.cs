using MediatR;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using System.Collections.Generic;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<List<UserResponse>>
    {
    }
}
