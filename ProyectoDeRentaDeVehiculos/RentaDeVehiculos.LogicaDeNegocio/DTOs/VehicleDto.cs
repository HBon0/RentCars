//namespace RentaDeVehiculos.LogicaDeNegocio.DTOs
//{
//    public class VehicleDto
//    {
//        public int Id { get; set; }
//        public string? Brand { get; set; }
//        public string? Model { get; set; }
//        public int? Year { get; set; }
//        public decimal? Price { get; set; }
//        public string? LicensePlate { get; set; }
//        public string? ImageUrl { get; set; }
//    }
//}

using MediatR;

namespace RentaDeVehiculos.LogicaDeNegocio.DTOs
{
    public class CreateVehicleRequest : IRequest<int>
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string? LicensePlate { get; set; }
        public string?  ImageUrl { get; set; }
    }
    public class UpdateVehicleRequets : IRequest<int>
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string? LicensePlate { get; set; }
        public string? ImageUrl { get; set; }
    }
    public class VehicleResponse : IRequest<int>
    {
        public int Id { get; set; }
    }

}

