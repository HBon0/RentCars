using Mapster;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;

namespace RentaDeVehiculos.LogicaDeNegocio.Mappings
{
    // Define la clase MappingRegister que implementa la interfaz IRegister
    public class MappingRegister : IRegister
    {
        // Método para registrar las configuraciones de mapeo
        public void Register(TypeAdapterConfig config)
        {
            // Configura un nuevo mapeo entre las clases Reservation y ReservationResponse
            config.NewConfig<Reservation, ReservationResponse>()
                // Mapea la propiedad Id de Reservation a la propiedad Id de ReservationResponse
                .Map(dest => dest.Id, src => src.Id)
                // Mapea la propiedad VehicleId de Reservation a la propiedad VehicleId de ReservationResponse
                .Map(dest => dest.VehicleId, src => src.VehicleId)
                // Mapea la propiedad CustomerId de Reservation a la propiedad CustomerId de ReservationResponse
                .Map(dest => dest.CustomerId, src => src.CustomerId)
                // Mapea la propiedad ReservationDate de Reservation a la propiedad ReservationDate de ReservationResponse
                .Map(dest => dest.ReservationDate, src => src.ReservationDate);

            // Configura un nuevo mapeo entre las clases Vehicle y VehicleResponse
            config.NewConfig<Vehicle, VehicleResponse>()
                .Map(dest => dest.Id, src => src.Id);

            



            // Configura un nuevo mapeo entre las clases Customer y CustomerResponse
            config.NewConfig<Customer, CustomerResponse>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest.PersonalDataId, src => src.PersonalDataId)
                .Map(dest => dest.RegistrationDate, src => src.RegistrationDate);
        }
    }
}
