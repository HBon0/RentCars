using MediatR;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Employees.Commands.UpdateEmployees
{


    public record UpdateEmployeesCommand(UpdateEmployeeRequest Request) : IRequest<int>;

}
