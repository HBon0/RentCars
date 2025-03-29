using MediatR;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio.UseCases.Employees.Commands.Queries.GetEmployee;

public record GetEmployeesQuery(int EmployeeId) : IRequest<EmployeeResponse>;


