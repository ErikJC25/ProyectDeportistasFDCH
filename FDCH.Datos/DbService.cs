using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using FDCH.Entidades; // Importamos la capa de entidades

namespace FDCH.Datos
{
    public class DbService
    {
        private const string DbFileName = "deportistas.db"; // Nombre del archivo de la BD
        private static readonly string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbFileName);

        /// <summary>
        /// Obtiene una conexión a la base de datos SQLite.
        /// </summary>
        private static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection($"Data Source={DbPath};Version=3;");
        }

        /// <summary>
        /// Inserta un nuevo deportista en la base de datos.
        /// </summary>
        /// <param name="deportista">Objeto Deportista con los datos a insertar.</param>
        /// <returns>El ID del nuevo deportista, o 0 si falla.</returns>
        public int InsertarDeportista(Deportista deportista)
        {
            int nuevoId = 0;
            using (SQLiteConnection connection = GetConnection())
            {
                string query = "INSERT INTO Deportistas (cedula, nombres, apellidos, genero, tipo_discapacidad) " +
                               "VALUES (@Cedula, @Nombres, @Apellidos, @Genero, @TipoDiscapacidad); " +
                               "SELECT last_insert_rowid();";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Cedula", deportista.cedula);
                    command.Parameters.AddWithValue("@Nombres", deportista.nombres);
                    command.Parameters.AddWithValue("@Apellidos", deportista.apellidos);
                    command.Parameters.AddWithValue("@Genero", deportista.genero);
                    command.Parameters.AddWithValue("@TipoDiscapacidad", deportista.tipo_discapacidad);

                    try
                    {
                        connection.Open();
                        nuevoId = Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar deportista: " + ex.Message);
                    }
                }
            }
            return nuevoId;
        }

        /// <summary>
        /// Obtiene una lista de todos los deportistas de la base de datos.
        /// </summary>
        public List<Deportista> ObtenerDeportistas()
        {
            List<Deportista> listaDeportistas = new List<Deportista>();
            using (SQLiteConnection connection = GetConnection())
            {
                string query = "SELECT * FROM Deportistas";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaDeportistas.Add(new Deportista
                                {
                                    id_deportista = Convert.ToInt32(reader["id_deportista"]),
                                    cedula = reader["cedula"].ToString(),
                                    nombres = reader["nombres"].ToString(),
                                    apellidos = reader["apellidos"].ToString(),
                                    genero = reader["genero"].ToString(),
                                    tipo_discapacidad = reader["tipo_discapacidad"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener deportistas: " + ex.Message);
                    }
                }
            }
            return listaDeportistas;
        }

        // Aquí irían los demás métodos para las operaciones CRUD de las otras tablas
    }
}