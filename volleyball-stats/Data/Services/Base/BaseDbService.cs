using System.Linq.Expressions;
using SQLite;

namespace volleyball_stats.Data.Services
{
    public class BaseDbService<T> where T : new()
    {
        private const string DB_NAME = "vb-stats.db3";
        private readonly SQLiteAsyncConnection _connection;

        public BaseDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(AppContext.BaseDirectory, DB_NAME));
            _connection.CreateTableAsync<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _connection.Table<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _connection.FindAsync<T>(id);
        }

        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate)
        {
            return await _connection.Table<T>().Where(predicate).ToListAsync();
        }

        public async Task<int> CreateAsync(T entity)
        {
            return await _connection.InsertAsync(entity);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            return await _connection.UpdateAsync(entity);
        }

        public async Task<int> DeleteAsync(T entity)
        {
            return await _connection.DeleteAsync(entity);
        }
    }
}