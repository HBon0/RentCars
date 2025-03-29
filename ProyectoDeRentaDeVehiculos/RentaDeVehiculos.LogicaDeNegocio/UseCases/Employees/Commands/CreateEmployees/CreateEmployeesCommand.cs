using MediatR;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Employees.Commands.CreateEmployees
{

    public record CreateEmployeesCommand(CreateEmployeeRequest Request) : IRequest<int>;




}
