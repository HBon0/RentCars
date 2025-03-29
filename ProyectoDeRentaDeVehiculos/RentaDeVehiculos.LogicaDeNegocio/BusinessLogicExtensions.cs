using FluentAssertions.Common;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentaDeVehiculos.AccesoDatos;
using RentaDeVehiculos.LogicaDeNegocio.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.LogicaDeNegocio
{
    // Clase estática que contiene métodos de extensión para la lógica de negocio
    public static class BusinessLogicExtensions
    {
        // Método de extensión para agregar servicios de lógica de negocio a la colección de servicios
        public static IServiceCollection AddBusinessLogicServices(
            this IServiceCollection services, // Colección de servicios a la que se agregarán los servicios de lógica de negocio
            IConfiguration configuration) // Configuración de la aplicación
        {
            // Agregar MediatR a la colección de servicios, registrando los servicios desde el ensamblado actual
            services.AddMediatR(
                cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

            // Agregar servicios de acceso a datos a la colección de servicios, utilizando la configuración proporcionada
            services.AddDataAccesServices(configuration);

            // Registrar las configuraciones de mapeo utilizando Mapster
            // Escanear el ensamblado actual en busca de configuraciones de mapeo
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
            // Aplicar las configuraciones de mapeo definidas en la clase MappingRegister
            TypeAdapterConfig.GlobalSettings.Apply(new MappingRegister());

            // Devolver la colección de servicios para permitir el encadenamiento de métodos
            return services;
        }
    }
}
