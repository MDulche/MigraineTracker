using SQLite;
using MigraineTracker.Models;

namespace MigraineTracker.Services
{
    public class DatabaseServices
    {
        private SQLiteConnection _db;

        public DatabaseServices()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "migraines.db");

            _db = new SQLiteConnection(filePath);

            _db.CreateTable<Migraine>();
        }

        public void Add(Migraine migraine)
        {
            _db.Insert(migraine);
        }

        public void Update(Migraine migraine)
        {
            _db.Update(migraine);
        }

        public List<Migraine> All()
        {
            return _db.Table<Migraine>().ToList();
        }

        public void Delete(int id)
        {
            _db.Delete<Migraine>(id);
        }
    }

    
}
