using OsoulSunna.Models;
using SQLite;

namespace OsoulSunna.Data
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;
        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<LocalBook>();
        }
        public Task<List<LocalBook>> GetAllbooks()
        {
            return _database.Table<LocalBook>().ToListAsync();
        }
        public Task<int> AddNew(LocalBook ex)
        {
            return _database.InsertAsync(ex);
        }
    }
}
