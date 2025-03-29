using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Employees.Commands.DeleteEmployees.CreateEmployees;
internal sealed class DeleteEMployeesHandler(IEfRepositorio<Employee> _repository)
    : IRequestHandler<DeleteEmployeesCommand, int>
{
    public async Task<int> Handle(DeleteEmployeesCommand command, CancellationToken cancellationToken)
    {

        {
            var existingEmployee = await _repository.GetByIdAsync(command.EmployeeId);
            if (existingEmployee is null) return 0;

            // 🔹 Aseguramos que no cambia el tipo de existingCustomer

            await _repository.DeleteAsync(existingEmployee, cancellationToken);
            return existingEmployee.Id;
        }


    }

}
