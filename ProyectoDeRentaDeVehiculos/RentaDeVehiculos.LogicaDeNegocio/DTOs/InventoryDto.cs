namespace RentaDeVehiculos.LogicaDeNegocio.DTOs
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public int? VehicleId { get; set; }
        public int? VehicleQuantity { get; set; }
        public string? VehicleStatus { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}
