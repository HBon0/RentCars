using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Vehicles.Commands.Queries.GetListVehicles
{
    internal class GetListQuery
    {
        public List<Vehicle> Execute()
        {
            // Aquí deberías agregar la lógica para obtener la lista de vehículos
            // Por ejemplo, podrías obtenerlos de una base de datos o de un servicio externo
            // Datos de ejemplo, cambiar mas adelante
            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Vehicle { Id = 1, Make = "Toyota", Model = "Corolla", Year = 2020 },
                new Vehicle { Id = 2, Make = "Honda", Model = "Civic", Year = 2019 },
                new Vehicle { Id = 3, Make = "Ford", Model = "Focus", Year = 2018 }
            };

            return vehicles;
        }
    }

    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}
