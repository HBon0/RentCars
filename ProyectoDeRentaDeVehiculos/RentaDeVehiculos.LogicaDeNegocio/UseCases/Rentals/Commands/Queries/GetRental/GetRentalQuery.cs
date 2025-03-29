using MediatR;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Rentals.Commands.Queries.GetRentals;

// Define un registro llamado GetRentalQuery que implementa la interfaz IRequest
// Este registro toma un parámetro RentalId de tipo int y devuelve una respuesta de tipo ReservationByIdResponse
public record GetRentalQuery(int RentalId) : IRequest<ReservationByIdResponse>;
