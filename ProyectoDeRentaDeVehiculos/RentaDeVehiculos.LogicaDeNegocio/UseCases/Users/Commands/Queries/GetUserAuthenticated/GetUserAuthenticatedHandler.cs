using MediatR;
using RentaDeVehiculos.Entidades;
using Microsoft.EntityFrameworkCore;
using RentaDeVehiculos.AccesoDatos;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Queries.GetUserAuthenticated;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Commands.Queries.GetUserAuthenticated
{
    public class GetUserAuthenticatedHandler : IRequestHandler<GetUserAuthenticatedQuery, UserResponse>
    {
        private readonly QuotationContext _context;

        public GetUserAuthenticatedHandler(QuotationContext context)
        {
            _context = context;
        }

        public async Task<UserResponse> Handle(GetUserAuthenticatedQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Include(u => u.PersonalData) // Si necesitas más información del usuario
                .FirstOrDefaultAsync(u => u.Username == request.UserName, cancellationToken);

            if (user == null || user.PasswordHash == null)
                return  null;

            // Aquí puedes verificar la contraseña si es un hash (Ejemplo: BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))

            return new UserResponse
            {
                Id = user.Id,
                Username = user.Username ?? string.Empty,
              /*  UserNickName = user.Username ?? string.Empty,*/ // Puedes cambiar esto si hay otro campo para 'nickname'
                RoleName = "Usuario" // Puedes reemplazarlo si el usuario tiene roles en la BD
            };
        }
    }
}
