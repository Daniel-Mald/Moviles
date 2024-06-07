using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppInventario.Models;
using Microsoft.Data.Sqlite;

namespace AppInventario.Data
{
    public class ArticuloDbContext
    {
        private const string _connectionString = "Data Source=articulos.db";
        public ArticuloDbContext()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"CREATE TABLE IF NOT EXISTS articulos(
                                       id INTEGER PRIMARY KEY AUTOINCREMENT,
                                       descripcion VARCHAR(60) NOT NULL,
                                       precio DECIMAL NOT NULL,
                                        existencia INTEGER NOT NULL
                                        );";
                command.ExecuteNonQuery();
                

            }
        }
        public async Task Agregar(Articulo articulo)
        {
            using (var conection = new SqliteConnection(_connectionString))
            {
                await conection.OpenAsync();
                var command = conection.CreateCommand();
                command.CommandText = @"INSERT INTO articulos(
                                        descripcion, precio, existencia)
                                         values ($descripcion, $precio, $existencia)";
                command.Parameters.AddWithValue("$descripcion", articulo.Descripcion);
                command.Parameters.AddWithValue("$precio", articulo.Precio);
                command.Parameters.AddWithValue("$existencia", articulo.Existencia);
                await command.ExecuteNonQueryAsync();
            }
        }
        public async Task Eliminar(int id)
        {
            using (var conection = new SqliteConnection(_connectionString))
            {
                await conection.OpenAsync();
                var command = conection.CreateCommand();
                command.CommandText = @"DELETE FROM articulos WHERE id = $id";
                command.Parameters.AddWithValue("$id", id);
                
                await command.ExecuteNonQueryAsync();
            }
        }
        public async Task Editar(Articulo articulo)
        {
            using (var conection = new SqliteConnection(_connectionString))
            {
                await conection.OpenAsync();
                var command = conection.CreateCommand();
                command.CommandText = @"UPDATE articulos SET descripcion = $descripcion, precio = $precio, existencia = $existencia
                                                WHERE id = $id";
                command.Parameters.AddWithValue("$id", articulo.Id);
                command.Parameters.AddWithValue("$descripcion", articulo.Descripcion);
                command.Parameters.AddWithValue("$precio", articulo.Precio);
                command.Parameters.AddWithValue("$existencia", articulo.Existencia);
                await command.ExecuteNonQueryAsync();
                
            }
        }

        public async Task<Articulo?> GetById(int id)
        {
            Articulo? articulo = null;
            if (id <= 0)
            {
                throw new ArgumentException("El id no es mayor a 0");
            }

            using (var conection = new SqliteConnection(_connectionString))
            {
                await conection.OpenAsync();
                var command = conection.CreateCommand();
                command.CommandText = @"SELECT * FROM articulos WHERE id = $id;";
                command.Parameters.AddWithValue("$id", id);


                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();
                        articulo = new Articulo()
                        {
                            Id = reader.GetInt32(0),
                            Descripcion = reader.GetString(1),
                            Precio = reader.GetDecimal(2),
                            Existencia = reader.GetInt32(3)
                        };


                    }


                }

            }
            return articulo;
        }
        public async Task<IEnumerable<Articulo>> GetAll()
        {
            List<Articulo> lista = new();
            using(var conection = new SqliteConnection(_connectionString))
            {
                await conection.OpenAsync();
                var command = conection.CreateCommand();
                command.CommandText = @"SELECT id , descripcion, existencia, precio
                                            FROM articulos";
                var reader = await command.ExecuteReaderAsync();
                while(await reader.ReadAsync())
                {
                    if(lista.Count == 0)
                    {
                        lista = new();
                    }
                    lista.Add(new Articulo
                    {
                        Id = reader.GetInt32(0),
                        Descripcion = reader.GetString(1),
                        Existencia = reader.GetInt16(2),
                        Precio = reader.GetDecimal(3),
                    });
                }
            }
            return lista;
        }
    }
}
