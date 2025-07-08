



using CurrencyExchange.Application.Services.Interfaces;
using CurrencyExchange.Core.Entities;
using CurrencyExchange.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq.Expressions;

namespace Market.api.Services
{

    public class Services<T> : IServices<T> where T : class
    {
        

        private readonly IUnitOfWork _unitOfWork;

        public Services(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<T?> GetByIdAsync(int id)
        {
            Expression<Func<T, bool>> filter = entity => EF.Property<int>(entity, "Id") == id;
            return await _unitOfWork.repository<T>().GetAsync(filter);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _unitOfWork.repository<T>().GetAllAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _unitOfWork.repository<T>().CreateAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _unitOfWork.repository<T>().UpdateAsync(entity);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                return false;

            await _unitOfWork.repository<T>().RemoveAsync(entity);
            return true;
        }

    }



}






