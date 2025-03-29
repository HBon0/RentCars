using MediatR;
using RentaDeVehiculos.AccesoDatos;
using RentaDeVehiculos.Entidades;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly QuotationContext _context;

        public CreateUserHandler(QuotationContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Hashear la contraseña antes de almacenarla
            var passwordHash = HashPassword(request.Password);

            var newUser = new User
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                PersonalDataId = request.PersonalDataId
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync(cancellationToken);

            return newUser.Id;
        }

        // Método para encriptar la contraseña con SHA256
        private byte[] HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}