using Mapster;
using MediatR;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using RentaDeVehiculos.Entidades;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.DeleteCustomer;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.UpdateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Employees.Commands.Queries.GetEmployees;
internal sealed class GetEmployeesHandler(IEfRepositorio<Employee> _repository)
    : IRequestHandler<GetEmployeesQuery, List<EmployeeResponse>>
{
    public async Task<List<EmployeeResponse>> Handle(GetEmployeesQuery query, CancellationToken cancellationToken)
    {
        
            var Employee = await _repository.ListAsync(cancellationToken);
            if (Employee == null || !Employee.Any())
            {

                return new List<EmployeeResponse>(); }

            // 🔹 Aseguramos que no cambia el tipo de existingCustomer

            return Employee.Adapt<List<EmployeeResponse>>();
        }

}
