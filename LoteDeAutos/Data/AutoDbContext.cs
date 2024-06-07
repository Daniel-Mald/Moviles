using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoteDeAutos.Models;
using Microsoft.Data.Sqlite;
using SQLite;


namespace LoteDeAutos.Data
{
    public class AutoDbContext
    {
        private const string _connectionString = "Data = Source=autos.db";
        private string _databaseFillName = "LoteDeAutos.db";
        
        const  SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public string _dataBasePath => Path.Combine(FileSystem.AppDataDirectory, _databaseFillName);
        private string _connectionString2 = "";


        SQLiteAsyncConnection _db;

        public async Task Init()
        {
            if(_db != null)
            {
                return;
            }
            _db = new SQLiteAsyncConnection(_dataBasePath, Flags);
            SQLite.CreateFlags _createFlags = CreateFlags.ImplicitPK | CreateFlags.AutoIncPK;
            var result = await _db.CreateTableAsync<Auto>(_createFlags);
        }
        public async Task Add(Auto _auto)
        {
            await Init();
            await _db.InsertAsync(_auto);
        }
        public async Task<Auto?> GetById(int id)
        {
            await Init();
            return await _db.Table<Auto>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Auto>?> GetAll()
        {
            await Init();
            return await _db.Table<Auto>().ToListAsync();
        }
        public async Task Update(Auto _auto)
        {
            await Init();
            await _db.UpdateAsync(_auto);
        }
        public async Task Delete(int id)
        {
            await Init();
            var _coche = await GetById(id);
            if (_coche != null)
            {
                await _db.DeleteAsync(_coche);
            }

        }
    }
}
