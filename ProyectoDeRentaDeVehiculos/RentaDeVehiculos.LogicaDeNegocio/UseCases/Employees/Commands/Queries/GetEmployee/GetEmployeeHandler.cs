using Mapster;
using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.Queries.GetCustomer;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Employees.Commands.Queries.GetEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Employees.Commands.Queries.GetEmployee;

internal sealed class GetEmployeesHandler(IEfRepositorio<Employee> _repository)
    : IRequestHandler<GetEmployeesQuery, EmployeeResponse>
{
    public async Task<EmployeeResponse> Handle(GetEmployeesQuery query, CancellationToken cancellationToken)
    {

        var Employee = await _repository.GetByIdAsync(query.EmployeeId, cancellationToken);
        if (Employee is null )
        {

            return new EmployeeResponse();
        }

        // 🔹 Aseguramos que no cambia el tipo de existingCustomer

        return Employee.Adapt<EmployeeResponse>();
    }

}

