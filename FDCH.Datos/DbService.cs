using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using FDCH.Entidades; // Importamos la capa de entidades

namespace FDCH.Datos
{
    public class DbService
    {
        private const string DbFileName = "deportistas.db"; // Nombre del archivo de la BD
        //private static readonly string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbFileName);

        // Ruta absoluta (a nivel local UNICA MAQUINA)
        //private static readonly string DbPath = @"C:\Ruta\A\TuProyecto\Data\deportistas.db";

        // Ruta relativa a la raíz del proyecto
        private static readonly string DbPath = Path.GetFullPath(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../BaseDatos", DbFileName)
        );

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
        public Usuario AutenticarUsuario(string usuario, string contrasena)
        {
            // Variable para almacenar el usuario autenticado (si existe)
            Usuario usuarioEncontrado = null;
            // Se abre una conexión a la base de datos
            using (SQLiteConnection connection = GetConnection())
            {
                // Consulta para buscar el usuario por nombre de usuario
                string query = "SELECT id_usuario, nombre_usuario, contrasena_hash, rol FROM Usuario WHERE nombre_usuario = @Usuario LIMIT 1";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    // Se agrega el parámetro del nombre de usuario
                    command.Parameters.AddWithValue("@Usuario", usuario);

                    try
                    {
                        connection.Open();
                        // Se ejecuta la consulta y se obtiene el resultado
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Se obtiene el hash de la contraseña almacenada
                                string contrasenaHashAlmacenada = reader["contrasena_hash"].ToString();
                                // Se calcula el hash de la contraseña ingresada
                                string contrasenaHashIngresada = CalcularSHA256(contrasena);

                                // Se compara el hash ingresado con el almacenado
                                if (contrasenaHashIngresada == contrasenaHashAlmacenada)
                                {
                                    // Si coinciden, se crea el objeto Usuario con los datos de la BD
                                    usuarioEncontrado = new Usuario
                                    {
                                        id_usuario = Convert.ToInt32(reader["id_usuario"]),
                                        nombre_usuario = reader["nombre_usuario"].ToString(),
                                        contrasena_hash = contrasenaHashAlmacenada,
                                        rol = reader["rol"].ToString()
                                    };
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // En caso de error, se muestra el mensaje en la consola
                        Console.WriteLine("Error al autenticar usuario: " + ex.Message);
                    }
                }
            }
            // Retorna el usuario autenticado o null si no existe o la contraseña es incorrecta
            return usuarioEncontrado;
        }

        // Método para calcular el hash SHA256 de un texto (usado para comparar contraseñas)
        private string CalcularSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convierte el texto a bytes y calcula el hash
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha256.ComputeHash(bytes);
                // Convierte el hash a una cadena hexadecimal
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

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