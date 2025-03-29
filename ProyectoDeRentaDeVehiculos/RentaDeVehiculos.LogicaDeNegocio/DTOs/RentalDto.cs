namespace RentaDeVehiculos.LogicaDeNegocio.DTOs
{
    public class CreateRentalRequest
    {
        public int? CustomerId { get; set; }
        public int? VehicleId { get; set; }
        public int? RentalDays { get; set; }
        public decimal? StartMileage { get; set; }
        public DateTime? RentalDate { get; set; } = DateTime.Now;
    }

    public class UpdateRentalRequest
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? VehicleId { get; set; }
        public int? RentalDays { get; set; }
        public decimal? StartMileage { get; set; }
        public decimal? FinalPrice { get; set; }
        public DateTime? RentalDate { get; set; }
    }

    public class RentalResponse
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? VehicleId { get; set; }
        public string? VehicleModel { get; set; }
        public int? RentalDays { get; set; }
        public decimal? StartMileage { get; set; }
        public decimal? FinalPrice { get; set; }
        public DateTime? RentalDate { get; set; }
    }
}
