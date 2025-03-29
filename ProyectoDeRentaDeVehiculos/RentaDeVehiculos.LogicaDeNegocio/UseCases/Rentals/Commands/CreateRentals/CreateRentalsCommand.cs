using MediatR;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Rentals.Commands.CreateRentals
{

    public record CreateRentalsCommand(CreateRentalRequest Request) : IRequest<int>;




}
