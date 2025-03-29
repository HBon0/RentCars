using RentaDeVehiculos.Entidades;

namespace RentaDeVehiculos.LogicaDeNegocio.DTOs
{
    // Clase para crear una solicitud de reserva
    public class CreateReservationRequest
    {
        // ID del cliente (puede ser nulo)
        public int? CustomerId { get; set; }

        // ID del vehículo (puede ser nulo)
        public int? VehicleId { get; set; }

        // Número de días de alquiler (puede ser nulo)
        public int? RentalDays { get; set; }

        // Fecha de la reserva (por defecto es la fecha actual)
        public DateTime? ReservationDate { get; set; } = DateTime.Now;
    }

    // Clase para actualizar una solicitud de reserva
    public class UpdateReservationRequest
    {
        // ID de la reserva
        public int Id { get; set; }

        // ID del cliente (puede ser nulo)
        public int? CustomerId { get; set; }

        // ID del vehículo (puede ser nulo)
        public int? VehicleId { get; set; }

        // Número de días de alquiler (puede ser nulo)
        public int? RentalDays { get; set; }

        // Fecha de la reserva (puede ser nulo)
        public DateTime? ReservationDate { get; set; }
    }

    // Clase para la respuesta de una reserva
    public class ReservationResponse
    {
        // ID de la reserva
        public int Id { get; set; }

        // ID del cliente (puede ser nulo)
        public int? CustomerId { get; set; }

        // Nombre del cliente (puede ser nulo)
        public string? CustomerName { get; set; }

        // ID del vehículo (puede ser nulo)
        public int? VehicleId { get; set; }

        // Modelo del vehículo (puede ser nulo)
        public string? VehicleModel { get; set; }

        // Número de días de alquiler (puede ser nulo)
        public int? RentalDays { get; set; }

        // Fecha de la reserva (puede ser nulo)
        public DateTime? ReservationDate { get; set; }
    }


    // Clase para la respuesta de una reserva por ID
    public class ReservationByIdResponse
    {
        // ID de la reserva
        public int Id { get; set; }

        // ID del cliente (puede ser nulo)
        public int? CustomerId { get; set; }

        // ID del vehículo (puede ser nulo)
        public int? VehicleId { get; set; }

        // Número de días de alquiler (puede ser nulo)
        public int? RentalDays { get; set; }

        // Fecha de la reserva (puede ser nulo)
        public DateTime? ReservationDate { get; set; }

        // Información del cliente (puede ser nulo)
        public virtual Customer? Customer { get; set; }

        // Información del vehículo (puede ser nulo)
        public virtual Vehicle? Vehicle { get; set; }
    }

}
