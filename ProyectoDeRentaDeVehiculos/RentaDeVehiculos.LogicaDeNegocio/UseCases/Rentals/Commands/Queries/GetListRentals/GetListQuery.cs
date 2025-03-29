using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Rentals.Commands.Queries.GetListRentals
{
    internal class GetListQuery
    {
        public List<Reservation> GetReservations()
        {
            // Aquí se implementaría la lógica para obtener la lista de reservas
            // Por ejemplo, se podría obtener de una base de datos o de un servicio externo
            return new List<Reservation>();
        }
    }

    public class Reservation
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Vehicle { get; set; }
    }
}
