using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Vehicles.Commands.DeleteVehicles;

public record DeleteVehicleCommand(int VehicleId) : IRequest<int>;
