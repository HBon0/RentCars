using MediatR;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Queries.GetUserAuthenticated

{
    public class GetUserAuthenticatedQuery : IRequest<UserResponse>
    {
        public readonly string Username;

        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public GetUserAuthenticatedQuery(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
