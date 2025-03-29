using Mapster;
using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Employees.Commands.CreateEmployees;

internal sealed class CreateEmployeesHandler(IEfRepositorio<Employee> _repository)
: IRequestHandler<CreateEmployeesCommand, int>
{
    public async Task<int> Handle(CreateEmployeesCommand command, CancellationToken cancellationToken)
    {
        try
        {

            var newEmployee = command.Request.Adapt<Employee>();
            var createEmployee = await _repository.AddAsync(newEmployee, cancellationToken);
            return createEmployee.Id;
        }
        catch (Exception)
        {
            return 0;
            throw;
        }
    }
}
