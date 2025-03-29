using MediatR;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Commands.CreateUser

{
    public class CreateUserCommand : IRequest<int>  // Retorna el ID del usuario creado
    {
        public string Username { get; set; }
        public string Password { get; set; }  // Se almacenará encriptada
        public int PersonalDataId { get; set; }
        public int RoleId { get; set; }  // ID del rol del usuario

        public CreateUserCommand(string username, string password, int personalDataId, int roleId)
        {
            Username = username;
            Password = password;
            PersonalDataId = personalDataId;
            RoleId = roleId;
        }
    }
}
public record CreateUserCommand(CreateUserRequest Request) : IRequest<int>;
