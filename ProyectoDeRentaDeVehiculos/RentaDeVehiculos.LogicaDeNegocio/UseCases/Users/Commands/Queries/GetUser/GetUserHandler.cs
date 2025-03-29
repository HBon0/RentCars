//using MediatR;
//using RentaDeVehiculos.LogicaDeNegocio.DTOs;
//using RentaDeVehiculos.Entidades;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Queries;
//using RentaDeVehiculos.AccesoDatos;

//namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Handlers
//{
//    public class GetUserHandler : IRequestHandler<GetUserQuery, List<UserResponse>>
//    {
//        private readonly QuotationContext _context;

//        public GetUserHandler(QuotationContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<UserResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
//        {
//            var query = _context.Users.AsQueryable();

//            if (request.Id.HasValue)
//            {
//                query = query.Where(u => u.Id == request.Id.Value);
//            }

//            var users = await Task.Run(() => query
//                .Select(u => new UserResponse
//                {
//                    Id = u.Id,
//                    Username = u.Username ?? string.Empty,
//                    PersonalDataId = u.PersonalDataId ?? 0,
//                    RoleName = u.PersonalData != null ? u.PersonalData.Employee.Role.Name : string.Empty
//                }).ToList(), cancellationToken);

//            return users;
//        }
//    }
//}


using MediatR;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using RentaDeVehiculos.Entidades;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Queries
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, UserResponse>
    {
        private readonly IEfRepositorio<User> _userRepository;

        public GetUserHandler(IEfRepositorio<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
                throw new KeyNotFoundException("Usuario no encontrado.");

            return new UserResponse
            {
                Id = user.Id,
                Username = user.Username ?? string.Empty,
                PersonalDataId = user.PersonalDataId ?? 0,
                RoleName = "Nombre del Rol" // Si tienes un campo Role, obtén el nombre correcto
            };
        }
    }
}
