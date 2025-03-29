using MediatR;
using Microsoft.EntityFrameworkCore;
using RentaDeVehiculos.AccesoDatos;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.Queries.GetRoles;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Queries.GetRoles
{
    internal sealed class GetRolesHandler : IRequestHandler<GetRolesQuery, List<RoleDto>>
    {
        private readonly QuotationContext _context;

        public GetRolesHandler(QuotationContext context)
        {
            _context = context;
        }

        public async Task<List<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Roles
                .Select(r => new RoleDto { Id = r.Id, Name = r.Name })
                .ToListAsync(cancellationToken);
        }
    }
}
