using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DatabaseService
{
    readonly SQLiteAsyncConnection _database;

    public DatabaseService(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Proveedor>().Wait();
    }

    public Task<List<Proveedor>> GetProveedoresAsync() => _database.Table<Proveedor>().ToListAsync();
    public Task<int> SaveProveedorAsync(Proveedor proveedor) => _database.InsertAsync(proveedor);
    public Task<int> DeleteProveedorAsync(Proveedor proveedor) => _database.DeleteAsync(proveedor);
}
