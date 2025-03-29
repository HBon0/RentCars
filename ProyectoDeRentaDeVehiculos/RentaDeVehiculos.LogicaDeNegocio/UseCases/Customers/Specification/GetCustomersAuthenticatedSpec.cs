using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using RentaDeVehiculos.Entidades;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Specifications
{
    public class GetCustomersAuthenticatedSpec : Specification<Customer>
    {
        public GetCustomersAuthenticatedSpec(string Username, byte[] PasswordHash)
        {
            if (string.IsNullOrEmpty(Username) || PasswordHash == null || PasswordHash.Length == 0)
            {
                throw new ArgumentException("El nombre de usuario y la contraseña no pueden estar vacíos.");
            }

            Query.Where(u => u.User != null && u.User.Username == Username && u.User.PasswordHash != null && u.User.PasswordHash.SequenceEqual(PasswordHash));

        }
    }
}

