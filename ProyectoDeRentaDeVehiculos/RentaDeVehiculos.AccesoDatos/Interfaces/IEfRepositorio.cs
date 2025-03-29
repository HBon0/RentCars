using Ardalis.Specification;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentaDeVehiculos.AccesoDatos.Interfaces
{
    public interface IEfRepositorio<T> : IRepositoryBase<T> where T : class
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task<T?> GetByIdAsync(int id);
        Task RollbackAsync();
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(T entity);
    }
}


