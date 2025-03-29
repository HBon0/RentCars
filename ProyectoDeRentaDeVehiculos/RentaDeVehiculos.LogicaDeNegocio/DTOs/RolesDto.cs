using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.DTOs
{
    public class CreateRoleRequest
    {
        public string Name { get; set; } = string.Empty;
    }

    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    
        public class UpdateRoleRequest
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
        }
    }






