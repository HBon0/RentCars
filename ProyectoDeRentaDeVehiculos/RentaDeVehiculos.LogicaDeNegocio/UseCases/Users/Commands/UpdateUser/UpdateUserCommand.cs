using MediatR;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int? PersonalDataId { get; set; }
        public string? Username { get; set; }
        public byte[]? PasswordHash { get; set; }

        public UpdateUserCommand(int id, int? personalDataId, string? username, byte[]? passwordHash)
        {
            Id = id;
            PersonalDataId = personalDataId;
            Username = username;
            PasswordHash = passwordHash;
        }
    }
}
public record UpdateUserCommand(UpdateUserRequest Request) : IRequest<int>;
