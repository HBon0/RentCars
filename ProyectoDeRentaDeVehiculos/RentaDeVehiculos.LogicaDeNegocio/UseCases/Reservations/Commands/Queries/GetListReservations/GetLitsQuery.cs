using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Reservations.Commands.Queries.GetListReservations
{
    public class GetListReservationsQuery
    {
        public List<Reservation> Execute()
        {
            // Aquí se debería implementar la lógica para obtener la lista de reservas
            // Por ahora, devolveremos una lista de ejemplo
            return new List<Reservation>
            {
                new Reservation { Id = 1, CustomerName = "Juan Perez", VehicleModel = "Toyota Corolla", ReservationDate = DateTime.Now },
                new Reservation { Id = 2, CustomerName = "Maria Lopez", VehicleModel = "Honda Civic", ReservationDate = DateTime.Now.AddDays(-1) }
            };
        }
    }

    public class Reservation
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string VehicleModel { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
