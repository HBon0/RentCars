using MediatR;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using System.Collections.Generic;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Queries


{
    public class GetUserQuery : IRequest<UserResponse> // Cambiado a un solo objeto en vez de lista
    {
        public int Id { get; }  // Cambiar de privado a público para poder accederlo

        public GetUserQuery(int id)
        { 
            Id = id;
        }

        public GetUserQuery()
        {
        }
    }
}









