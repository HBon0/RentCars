using MediatR;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserResponse>>
    {
        private readonly IEfRepositorio<User> _userRepository;
        private readonly IEfRepositorio<Role> _roleRepository;

        public GetUsersQueryHandler(IEfRepositorio<User> userRepository, IEfRepositorio<Role> roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<List<UserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.ListAsync(cancellationToken);
            var roles = await _roleRepository.ListAsync(cancellationToken);

            var userResponses = users.Select(user => new UserResponse
            {
                Id = user.Id,
                Username = user.Username ?? string.Empty,
                PersonalDataId = user.PersonalDataId ?? 0,
                RoleName = roles.FirstOrDefault(r => r.Id == user.Employee?.RoleId)?.Name ?? "Sin Rol"
            }).ToList();

            return userResponses;
        }
    }
}
