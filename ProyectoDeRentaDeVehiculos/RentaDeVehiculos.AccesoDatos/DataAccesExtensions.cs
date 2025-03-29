using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentaDeVehiculos.AccesoDatos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVehiculos.AccesoDatos
{
    public static class DataAccessExtensions
    {
        public static IServiceCollection AddDataAccesServices
            (
            this IServiceCollection services,
            IConfiguration configuration  
            
            )
        {
            services.AddDbContext<QuotationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnection") ??
                     throw new InvalidOperationException("connection string 'DbContext not found'")));


            services.AddTransient(typeof(IEfRepositorio<>), typeof(IEfRepositorio<>));

            return services;

        }
    }
}
