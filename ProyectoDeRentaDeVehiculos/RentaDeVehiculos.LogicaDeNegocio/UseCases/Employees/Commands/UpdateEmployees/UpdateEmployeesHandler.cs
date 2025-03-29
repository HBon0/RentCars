using Mapster;
using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;


namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Employees.Commands.UpdateEmployees;

internal sealed class UpdateEmployeesHandler(IEfRepositorio<Employee> _repository)
    : IRequestHandler<UpdateEmployeesCommand, int>
{
    public async Task<int> Handle(UpdateEmployeesCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var existingEmployee = await _repository.GetByIdAsync(command.Request.Id);
            if (existingEmployee == null) return 0;

            // 🔹 Aseguramos que no cambia el tipo de existingCustomer
            command.Request.Adapt(existingEmployee);

            await _repository.UpdateAsync(existingEmployee);

            return existingEmployee.Id; // 🔹 Aquí ya debería existir Id
        }
        catch (Exception)
        {
            return 0;
        }

    }

}
