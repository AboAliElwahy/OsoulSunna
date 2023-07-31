using OsoulSunna.Models;
using SQLite;

namespace OsoulSunna.Data
{
    public class DataRepository
    {
        private readonly SQLiteConnection _database;
        public static string DbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Osoul.db3");

        public DataRepository()
        {
            _database = new SQLiteConnection(DbPath);
            _database.CreateTable<Book>();
        }
        public List<Book> GetAllBooks()
        {
            return _database.Table<Book>().ToList();
        }
    }
}
