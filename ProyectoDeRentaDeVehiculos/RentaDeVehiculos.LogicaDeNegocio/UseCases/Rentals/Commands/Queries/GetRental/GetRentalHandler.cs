using Mapster;
using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Rentals.Commands.Queries.GetRentals;

// Definimos la clase GetRentalsHandler que implementa IRequestHandler
internal sealed class GetRentalsHandler : IRequestHandler<GetRentalQuery, ReservationByIdResponse>
{
    // Declaramos una variable privada para el repositorio
    private readonly IEfRepositorio<Rental> _repository;

    // Constructor que inicializa el repositorio
    public GetRentalsHandler(IEfRepositorio<Rental> repository)
    {
        _repository = repository;
    }

    // Método Handle que maneja la consulta GetRentalQuery
    public async Task<ReservationByIdResponse> Handle(GetRentalQuery query, CancellationToken cancellationToken)
    {
        // Obtenemos el alquiler por su ID desde el repositorio
        var rental = await _repository.GetByIdAsync(query.RentalId, cancellationToken);

        // Si el alquiler no existe, devolvemos una respuesta vacía
        if (rental is null)
        {
            return new ReservationByIdResponse();
        }

        // Convertimos el objeto Rental a ReservationByIdResponse y lo devolvemos
        return rental.Adapt<ReservationByIdResponse>();
    }
}

