namespace RentaDeVehiculos.LogicaDeNegocio.DTOs
{
    public class ReturnDto
    {
        public int Id { get; set; }
        public int? RentalId { get; set; }
        public decimal? ReturnMileage { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}
