using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CTO.Models.Data
{
    public class CTOContext
    {
        SQLiteAsyncConnection Database;
        async Task InitAsync()
        {
            if (Database is not null)
                return;
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Database.CreateTableAsync<User>();
        }

        public async Task<List<TEntity>> GetAllAsync<TEntity>() where TEntity : class, new()
        {
            await InitAsync();
            return await Database.Table<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetItemsNotDoneAsync<TEntity>(Expression<Func<TEntity, bool>> pred) where TEntity : class, new()
        {
            await InitAsync();
            return await Database.Table<TEntity>().Where(pred).ToListAsync();
        }

        public async Task<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>> pred) where TEntity : class, new()
        {
            await InitAsync();
            return await Database.Table<TEntity>().FirstOrDefaultAsync(pred);
        }

        public async Task AddAsync<TEntity>(TEntity model) where TEntity : class, new()
        {
            await InitAsync();
            await Database.InsertAsync(model);
        }
           

        public async Task UpdateAsync<TEntity>(TEntity model) where TEntity : class, new()
        {
            await InitAsync();
            await Database.UpdateAsync(model);
        }

        public async Task DeleteItemAsync<TEntity>(TEntity model) where TEntity : class, new()
        {
            await InitAsync();
            await Database.DeleteAsync(model);
        }
    }
}
