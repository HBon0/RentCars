using MediatR;
using Microsoft.EntityFrameworkCore;
using RentaDeVehiculos.AccesoDatos;
using RentaDeVehiculos.Entidades;
using System.Threading;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly QuotationContext _context;

        public UpdateUserHandler(QuotationContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id);

            if (user == null)
                return 0; // No se encontró el usuario

            // Actualizar los campos del usuario
            user.PersonalDataId = request.PersonalDataId ?? user.PersonalDataId;
            user.Username = request.Username ?? user.Username;
            user.PasswordHash = request.PasswordHash ?? user.PasswordHash;

            _context.Users.Update(user);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
