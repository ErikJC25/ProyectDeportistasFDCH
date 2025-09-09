using FDCH.Entidades; // Importamos la capa de entidades
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FDCH.Datos
{
    public class DbService
    {
        public const string DbFileName = "BDCompetencias.db"; // Nombre del archivo de la BD

        // Ruta absoluta (a nivel local UNICA MAQUINA)
        //private static readonly string DbPath = @"C:\Ruta\A\TuProyecto\Data\deportistas.db";

        // Ruta relativa a la raíz del proyecto
        private static readonly string DbPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../FDCH.Datos/Archivos", DbFileName));
        //bryan private static readonly string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "semifinal.db");

        // Ruta absoluta (a nivel local, para todos los usuarios)
        //public static readonly string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbFileName);




        /// <summary>
        /// Obtiene una conexión a la base de datos SQLite.
        /// </summary>
        public static SQLiteConnection GetConnection(){return new SQLiteConnection($"Data Source={DbPath};Version=3;"); }
        //BRYAN public static SQLiteConnection GetConnection(){var connectionString = $"Data Source={DbPath};Version=3;Pooling=true;Max Pool Size=100;Connection Timeout=30;"; return new SQLiteConnection(connectionString);}
        public static string GetDbPath()
        {
            return DbPath;
        }
        public static void ForzarReconectar()
        {
            // Esto cierra todas las conexiones antiguas que SQLite tenga en caché
            SQLiteConnection.ClearAllPools();
        }


        public Usuario AutenticarUsuario(string usuario, string contrasena)
        {
            // Variable para almacenar el usuario autenticado (si existe)
            Usuario usuarioEncontrado = null;
            // Se abre una conexión a la base de datos
            using (SQLiteConnection connection = GetConnection())
            {
                // Consulta para buscar el usuario por nombre de usuario
                string query = "SELECT id_usuario, nombre_usuario, contrasena_hash, rol FROM Usuarios WHERE nombre_usuario = @Usuario LIMIT 1";
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
//IMPORTANTE --------------->

                                //SIGUIENTE BLOQUE PARA PROBAR SIN HASH DE CONTRASEÑAS (BORRAR AL FINAL)

                                if (contrasena == reader["contrasena_hash"].ToString())
                                {
                                    // Si coinciden, se crea el objeto Usuario con los datos de la BD
                                    usuarioEncontrado = new Usuario
                                    {
                                        id_usuario = Convert.ToInt32(reader["id_usuario"]),
                                        nombre_usuario = reader["nombre_usuario"].ToString(),
                                        contrasena_hash = reader["contrasena_hash"].ToString(),
                                        rol = reader["rol"].ToString()
                                    };
                                }



                                //DESCOMENTAR EL SIGUIETE BLOQUE PARA HACER HASH DE CONTRASEÑAS (FINAL)

                                //// Se obtiene el hash de la contraseña almacenada
                                //string contrasenaHashAlmacenada = reader["contrasena_hash"].ToString();
                                //// Se calcula el hash de la contraseña ingresada
                                //string contrasenaHashIngresada = CalcularSHA256(contrasena);

                                //// Se compara el hash ingresado con el almacenado
                                //if (contrasenaHashIngresada == contrasenaHashAlmacenada)
                                //{
                                //    // Si coinciden, se crea el objeto Usuario con los datos de la BD
                                //    usuarioEncontrado = new Usuario
                                //    {
                                //        id_usuario = Convert.ToInt32(reader["id_usuario"]),
                                //        nombre_usuario = reader["nombre_usuario"].ToString(),
                                //        contrasena_hash = contrasenaHashAlmacenada,
                                //        rol = reader["rol"].ToString()
                                //    };
                                //}
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

        /// <summary>
        /// Inserta un nuevo deportista en la base de datos.
        /// </summary>
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


        public Deportista ObtieneDeportista(int idBusca)
        {
            Deportista objDeportista = new Deportista();
            using (SQLiteConnection connection = GetConnection())
            {
                string query = "SELECT * FROM Deportistas WHERE id_deportista = @IdDeportista";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdDeportista", idBusca);

                    try
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                objDeportista.id_deportista = Convert.ToInt32(reader["id_deportista"]);
                                objDeportista.cedula = reader["cedula"].ToString();
                                objDeportista.nombres = reader["nombres"].ToString();
                                objDeportista.apellidos = reader["apellidos"].ToString();
                                objDeportista.genero = reader["genero"].ToString();
                                objDeportista.tipo_discapacidad = reader["tipo_discapacidad"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener deportista: " + ex.Message);
                    }
                }
            }
            return objDeportista;
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

        public List<RegistroTotal> ObtenerRegistrosCompletosDB()
        {
            var lista = new List<RegistroTotal>();
            using (var connection = GetConnection())
            {
                string query = @"
                    SELECT 
                        d.id_deportista AS IdDeportista,
                        d.cedula AS Cedula,
                        d.nombres AS Nombres,
                        d.apellidos AS Apellidos,
                        d.genero AS Genero,
                        d.tipo_discapacidad AS TipoDiscapacidad,
                        t.id_tecnico AS IdTecnico,
                        t.nombre_completo AS NombreCompletoTecnico,
                        e.id_evento AS IdEvento,
                        e.nombre_evento AS NombreEvento,
                        e.lugar AS Lugar,
                        e.fecha_inicio AS FechaInicio,
                        e.fecha_fin AS FechaFin,
                        e.tipo_evento AS TipoEvento,
                        e.nivel_evento AS NivelEvento,
                        dis.id_disciplina AS IdDisciplina,
                        dis.nombre_disciplina AS NombreDisciplina,
                        esp.id_especialidad AS IdEspecialidad,
                        esp.nombre_especialidad AS NombreEspecialidad,
                        esp.modalidad AS Modalidad,
                        c.id_competencia AS IdCompetencia,
                        c.categoria AS Categoria,
                        c.division AS Division,
                        c.numero_participantes AS NumeroParticipantes,
                        c.record AS Record,
                        des.id_desempeno AS IdDesempeno,
                        des.puntos AS Puntos,
                        des.medalla AS Medalla,
                        des.observaciones AS Observaciones,
                        des.tiempo AS Tiempo,
                        des.ubicacion AS Ubicacion
                    FROM Desempeno des
                    INNER JOIN Deportistas d ON des.id_deportista = d.id_deportista
                    INNER JOIN Competencias c ON des.id_competencia = c.id_competencia
                    INNER JOIN Tecnicos t ON des.id_tecnico = t.id_tecnico
                    INNER JOIN Eventos e ON c.id_evento = e.id_evento
                    INNER JOIN Especialidades esp ON c.id_especialidad = esp.id_especialidad
                    INNER JOIN Disciplinas dis ON esp.id_disciplina = dis.id_disciplina
                    ORDER BY des.id_desempeno DESC
                ";

                using (var command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var registro = new RegistroTotal
                                {
                                    IdDeportista = reader["IdDeportista"] != DBNull.Value ? Convert.ToInt32(reader["IdDeportista"]) : 0,
                                    Cedula = reader["Cedula"]?.ToString(),
                                    Nombres = reader["Nombres"]?.ToString(),
                                    Apellidos = reader["Apellidos"]?.ToString(),
                                    Genero = reader["Genero"]?.ToString(),
                                    TipoDiscapacidad = reader["TipoDiscapacidad"]?.ToString(),
                                    IdTecnico = reader["IdTecnico"] != DBNull.Value ? Convert.ToInt32(reader["IdTecnico"]) : 0,
                                    NombreCompletoTecnico = reader["NombreCompletoTecnico"]?.ToString(),
                                    IdEvento = reader["IdEvento"] != DBNull.Value ? Convert.ToInt32(reader["IdEvento"]) : 0,
                                    NombreEvento = reader["NombreEvento"]?.ToString(),
                                    Lugar = reader["Lugar"]?.ToString(),
                                    FechaInicio = reader["FechaInicio"]?.ToString(),
                                    FechaFin = reader["FechaFin"]?.ToString(),
                                    TipoEvento = reader["TipoEvento"]?.ToString(),
                                    NivelEvento = reader["NivelEvento"]?.ToString(),
                                    IdDisciplina = reader["IdDisciplina"] != DBNull.Value ? Convert.ToInt32(reader["IdDisciplina"]) : 0,
                                    NombreDisciplina = reader["NombreDisciplina"]?.ToString(),
                                    IdEspecialidad = reader["IdEspecialidad"] != DBNull.Value ? Convert.ToInt32(reader["IdEspecialidad"]) : 0,
                                    NombreEspecialidad = reader["NombreEspecialidad"]?.ToString(),
                                    Modalidad = reader["Modalidad"]?.ToString(),
                                    IdCompetencia = reader["IdCompetencia"] != DBNull.Value ? Convert.ToInt32(reader["IdCompetencia"]) : 0,
                                    Categoria = reader["Categoria"]?.ToString(),
                                    Division = reader["Division"]?.ToString(),
                                    NumeroParticipantes = reader["NumeroParticipantes"]?.ToString(),
                                    Record = reader["Record"]?.ToString(),
                                    IdDesempeno = reader["IdDesempeno"] != DBNull.Value ? Convert.ToInt32(reader["IdDesempeno"]) : 0,
                                    Puntos = reader["Puntos"]?.ToString(),
                                    Medalla = reader["Medalla"]?.ToString(),
                                    Observaciones = reader["Observaciones"]?.ToString(),
                                    Tiempo = reader["Tiempo"]?.ToString(),
                                    Ubicacion = reader["Ubicacion"]?.ToString()
                                };
                                lista.Add(registro);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener registros completos: " + ex.Message);
                    }
                }
            }
            return lista;
        }



        public List<RegistroTotal> ObtenerRegistrosCompletosDBPersonal(int idBuscar)
        {
            var lista = new List<RegistroTotal>();
            using (var connection = GetConnection())
            {
                string query = @"
                    SELECT 
                        d.id_deportista AS IdDeportista,
                        d.cedula AS Cedula,
                        d.nombres AS Nombres,
                        d.apellidos AS Apellidos,
                        d.genero AS Genero,
                        d.tipo_discapacidad AS TipoDiscapacidad,
                        t.id_tecnico AS IdTecnico,
                        t.nombre_completo AS NombreCompletoTecnico,
                        e.id_evento AS IdEvento,
                        e.nombre_evento AS NombreEvento,
                        e.lugar AS Lugar,
                        e.fecha_inicio AS FechaInicio,
                        e.fecha_fin AS FechaFin,
                        e.tipo_evento AS TipoEvento,
                        e.nivel_evento AS NivelEvento,
                        dis.id_disciplina AS IdDisciplina,
                        dis.nombre_disciplina AS NombreDisciplina,
                        esp.id_especialidad AS IdEspecialidad,
                        esp.nombre_especialidad AS NombreEspecialidad,
                        esp.modalidad AS Modalidad,
                        c.id_competencia AS IdCompetencia,
                        c.categoria AS Categoria,
                        c.division AS Division,
                        c.numero_participantes AS NumeroParticipantes,
                        c.record AS Record,
                        des.id_desempeno AS IdDesempeno,
                        des.puntos AS Puntos,
                        des.medalla AS Medalla,
                        des.observaciones AS Observaciones,
                        des.tiempo AS Tiempo,
                        des.ubicacion AS Ubicacion
                    FROM Desempeno des
                    INNER JOIN Deportistas d ON des.id_deportista = d.id_deportista
                    INNER JOIN Competencias c ON des.id_competencia = c.id_competencia
                    INNER JOIN Tecnicos t ON des.id_tecnico = t.id_tecnico
                    INNER JOIN Eventos e ON c.id_evento = e.id_evento
                    INNER JOIN Especialidades esp ON c.id_especialidad = esp.id_especialidad
                    INNER JOIN Disciplinas dis ON esp.id_disciplina = dis.id_disciplina
                    WHERE d.id_deportista = @IdDeportista
                    ORDER BY des.id_desempeno DESC
                ";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdDeportista", idBuscar);

                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var registro = new RegistroTotal
                                {
                                    IdDeportista = reader["IdDeportista"] != DBNull.Value ? Convert.ToInt32(reader["IdDeportista"]) : 0,
                                    Cedula = reader["Cedula"]?.ToString(),
                                    Nombres = reader["Nombres"]?.ToString(),
                                    Apellidos = reader["Apellidos"]?.ToString(),
                                    Genero = reader["Genero"]?.ToString(),
                                    TipoDiscapacidad = reader["TipoDiscapacidad"]?.ToString(),
                                    IdTecnico = reader["IdTecnico"] != DBNull.Value ? Convert.ToInt32(reader["IdTecnico"]) : 0,
                                    NombreCompletoTecnico = reader["NombreCompletoTecnico"]?.ToString(),
                                    IdEvento = reader["IdEvento"] != DBNull.Value ? Convert.ToInt32(reader["IdEvento"]) : 0,
                                    NombreEvento = reader["NombreEvento"]?.ToString(),
                                    Lugar = reader["Lugar"]?.ToString(),
                                    FechaInicio = reader["FechaInicio"]?.ToString(),
                                    FechaFin = reader["FechaFin"]?.ToString(),
                                    TipoEvento = reader["TipoEvento"]?.ToString(),
                                    NivelEvento = reader["NivelEvento"]?.ToString(),
                                    IdDisciplina = reader["IdDisciplina"] != DBNull.Value ? Convert.ToInt32(reader["IdDisciplina"]) : 0,
                                    NombreDisciplina = reader["NombreDisciplina"]?.ToString(),
                                    IdEspecialidad = reader["IdEspecialidad"] != DBNull.Value ? Convert.ToInt32(reader["IdEspecialidad"]) : 0,
                                    NombreEspecialidad = reader["NombreEspecialidad"]?.ToString(),
                                    Modalidad = reader["Modalidad"]?.ToString(),
                                    IdCompetencia = reader["IdCompetencia"] != DBNull.Value ? Convert.ToInt32(reader["IdCompetencia"]) : 0,
                                    Categoria = reader["Categoria"]?.ToString(),
                                    Division = reader["Division"]?.ToString(),
                                    NumeroParticipantes = reader["NumeroParticipantes"]?.ToString(),
                                    Record = reader["Record"]?.ToString(),
                                    IdDesempeno = reader["IdDesempeno"] != DBNull.Value ? Convert.ToInt32(reader["IdDesempeno"]) : 0,
                                    Puntos = reader["Puntos"]?.ToString(),
                                    Medalla = reader["Medalla"]?.ToString(),
                                    Observaciones = reader["Observaciones"]?.ToString(),
                                    Tiempo = reader["Tiempo"]?.ToString(),
                                    Ubicacion = reader["Ubicacion"]?.ToString()
                                };
                                lista.Add(registro);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener registros completos: " + ex.Message);
                    }
                }
            }
            return lista;
        }



        // Inserta un nuevo técnico
        public int InsertarTecnico(Tecnico tecnico)
        {
            int nuevoId = 0;
            using (var connection = GetConnection())
            {
                string query = "INSERT INTO Tecnicos (nombre_completo) VALUES (@NombreCompleto); SELECT last_insert_rowid();";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreCompleto", tecnico.nombre_completo);
                    try
                    {
                        connection.Open();
                        nuevoId = Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar técnico: " + ex.Message);
                    }
                }
            }
            return nuevoId;
        }

        // Consulta todos los técnicos
        public List<Tecnico> ObtenerTecnicos()
        {
            var lista = new List<Tecnico>();
            using (var connection = GetConnection())
            {
                string query = "SELECT * FROM Tecnicos ORDER BY nombre_completo ASC";
                using (var command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Tecnico
                                {
                                    id_tecnico = Convert.ToInt32(reader["id_tecnico"]),
                                    nombre_completo = reader["nombre_completo"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener técnicos: " + ex.Message);
                    }
                }
            }
            return lista;
        }

        // Inserta un nuevo evento
        public int InsertarEvento(Evento evento)
        {
            int nuevoId = 0;
            using (var connection = GetConnection())
            {
                string query = @"INSERT INTO Eventos (nombre_evento, lugar, fecha_inicio, fecha_fin, tipo_evento, nivel_evento)
                                 VALUES (@NombreEvento, @Lugar, @FechaInicio, @FechaFin, @TipoEvento, @NivelEvento);
                                 SELECT last_insert_rowid();";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreEvento", evento.nombre_evento);
                    command.Parameters.AddWithValue("@Lugar", evento.lugar);
                    command.Parameters.AddWithValue("@FechaInicio", evento.fecha_inicio);
                    command.Parameters.AddWithValue("@FechaFin", evento.fecha_fin);
                    command.Parameters.AddWithValue("@TipoEvento", evento.tipo_evento);
                    command.Parameters.AddWithValue("@NivelEvento", evento.nivel_evento);
                    try
                    {
                        connection.Open();
                        nuevoId = Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar evento: " + ex.Message);
                    }
                }
            }
            return nuevoId;
        }

        public Evento ObtieneTorneo(int idBusca)
        {
            Evento objevento = new Evento();
            using (var connection = GetConnection())
            {

                string query = "SELECT * FROM Eventos WHERE id_evento = @IdEvento";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdEvento", idBusca);

                    try
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                objevento.id_evento = Convert.ToInt32(reader["id_evento"]);
                                objevento.nombre_evento = reader["nombre_evento"].ToString();
                                objevento.lugar = reader["lugar"].ToString();
                                objevento.fecha_inicio = reader["fecha_inicio"].ToString();
                                objevento.fecha_fin = reader["fecha_fin"].ToString();
                                objevento.tipo_evento = reader["tipo_evento"].ToString();
                                objevento.nivel_evento = reader["nivel_evento"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener evento: " + ex.Message);
                    }
                }
            }
            return objevento;
        }



        // Consulta todos los eventos
        public List<Evento> ObtenerEventos()
        {
            var lista = new List<Evento>();
            using (var connection = GetConnection())
            {
                string query = "SELECT * FROM Eventos ORDER BY nombre_evento ASC";
                using (var command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Evento
                                {
                                    id_evento = Convert.ToInt32(reader["id_evento"]),
                                    nombre_evento = reader["nombre_evento"].ToString(),
                                    lugar = reader["lugar"].ToString(),
                                    fecha_inicio = reader["fecha_inicio"].ToString(),
                                    fecha_fin = reader["fecha_fin"].ToString(),
                                    tipo_evento = reader["tipo_evento"].ToString(),
                                    nivel_evento = reader["nivel_evento"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener eventos: " + ex.Message);
                    }
                }
            }
            return lista;
        }

        // Inserta una nueva disciplina
        public int InsertarDisciplina(Disciplina disciplina)
        {
            int nuevoId = 0;
            using (var connection = GetConnection())
            {
                string query = "INSERT INTO Disciplinas (nombre_disciplina) VALUES (@NombreDisciplina); SELECT last_insert_rowid();";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreDisciplina", disciplina.nombre_disciplina);
                    try
                    {
                        connection.Open();
                        nuevoId = Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar disciplina: " + ex.Message);
                    }
                }
            }
            return nuevoId;
        }

        // Consulta todas las disciplinas
        public List<Disciplina> ObtenerDisciplinas()
        {
            var lista = new List<Disciplina>();
            using (var connection = GetConnection())
            {
                string query = "SELECT * FROM Disciplinas";
                using (var command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Disciplina
                                {
                                    id_disciplina = Convert.ToInt32(reader["id_disciplina"]),
                                    nombre_disciplina = reader["nombre_disciplina"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener disciplinas: " + ex.Message);
                    }
                }
            }
            return lista;
        }

        // Inserta una nueva especialidad
        public int InsertarEspecialidad(Especialidad especialidad)
        {
            int nuevoId = 0;
            using (var connection = GetConnection())
            {
                string query = @"INSERT INTO Especialidades (nombre_especialidad, modalidad, id_disciplina)
                                 VALUES (@NombreEspecialidad, @Modalidad, @IdDisciplina);
                                 SELECT last_insert_rowid();";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreEspecialidad", especialidad.nombre_especialidad);
                    command.Parameters.AddWithValue("@Modalidad", especialidad.modalidad);
                    command.Parameters.AddWithValue("@IdDisciplina", especialidad.id_disciplina);
                    try
                    {
                        connection.Open();
                        nuevoId = Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar especialidad: " + ex.Message);
                    }
                }
            }
            return nuevoId;
        }

        // Consulta todas las especialidades
        public List<Especialidad> ObtenerEspecialidades()
        {
            var lista = new List<Especialidad>();
            using (var connection = GetConnection())
            {
                string query = "SELECT * FROM Especialidades";
                using (var command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Especialidad
                                {
                                    id_especialidad = Convert.ToInt32(reader["id_especialidad"]),
                                    nombre_especialidad = reader["nombre_especialidad"].ToString(),
                                    modalidad = reader["modalidad"].ToString(),
                                    id_disciplina = Convert.ToInt32(reader["id_disciplina"])
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener especialidades: " + ex.Message);
                    }
                }
            }
            return lista;
        }

        // Inserta una nueva competencia
        public int InsertarCompetencia(Competencia competencia)
        {
            int nuevoId = 0;
            using (var connection = GetConnection())
            {
                string query = @"INSERT INTO Competencias (categoria, division, numero_participantes, record, id_evento, id_especialidad)
                                 VALUES (@Categoria, @Division, @NumeroParticipantes, @Record, @IdEvento, @IdEspecialidad);
                                 SELECT last_insert_rowid();";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Categoria", competencia.categoria);
                    command.Parameters.AddWithValue("@Division", competencia.division);
                    command.Parameters.AddWithValue("@NumeroParticipantes", competencia.numero_participantes);
                    command.Parameters.AddWithValue("@Record", competencia.record);
                    command.Parameters.AddWithValue("@IdEvento", competencia.id_evento);
                    command.Parameters.AddWithValue("@IdEspecialidad", competencia.id_especialidad);
                    try
                    {
                        connection.Open();
                        nuevoId = Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar competencia: " + ex.Message);
                    }
                }
            }
            return nuevoId;
        }

        // Consulta todas las competencias
        public List<Competencia> ObtenerCompetencias()
        {
            var lista = new List<Competencia>();
            using (var connection = GetConnection())
            {
                string query = "SELECT * FROM Competencias";
                using (var command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Competencia
                                {
                                    id_competencia = Convert.ToInt32(reader["id_competencia"]),
                                    categoria = reader["categoria"].ToString(),
                                    division = reader["division"].ToString(),
                                    numero_participantes = reader["numero_participantes"].ToString(),
                                    record = reader["record"].ToString(),
                                    id_evento = Convert.ToInt32(reader["id_evento"]),
                                    id_especialidad = Convert.ToInt32(reader["id_especialidad"])
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener competencias: " + ex.Message);
                    }
                }
            }
            return lista;
        }

        // Inserta un nuevo desempeño
        public int InsertarDesempeno(Desempeno desempeno)
        {
            int nuevoId = 0;
            using (var connection = GetConnection())
            {
                string query = @"INSERT INTO Desempeno (puntos, medalla, observaciones, tiempo, ubicacion, id_deportista, id_competencia, id_tecnico)
                                 VALUES (@Puntos, @Medalla, @Observaciones, @Tiempo, @Ubicacion, @IdDeportista, @IdCompetencia, @IdTecnico);
                                 SELECT last_insert_rowid();";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Puntos", desempeno.puntos);
                    command.Parameters.AddWithValue("@Medalla", desempeno.medalla);
                    command.Parameters.AddWithValue("@Observaciones", desempeno.observaciones);
                    command.Parameters.AddWithValue("@Tiempo", desempeno.tiempo);
                    command.Parameters.AddWithValue("@Ubicacion", desempeno.ubicacion);
                    command.Parameters.AddWithValue("@IdDeportista", desempeno.id_deportista);
                    command.Parameters.AddWithValue("@IdCompetencia", desempeno.id_competencia);
                    command.Parameters.AddWithValue("@IdTecnico", desempeno.id_tecnico);
                    try
                    {
                        connection.Open();
                        nuevoId = Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar desempeño: " + ex.Message);
                    }
                }
            }
            return nuevoId;
        }

        // Consulta todos los desempeños
        public List<Desempeno> ObtenerDesempenos()
        {
            var lista = new List<Desempeno>();
            using (var connection = GetConnection())
            {
                string query = "SELECT * FROM Desempeno";
                using (var command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Desempeno
                                {
                                    id_desempeno = Convert.ToInt32(reader["id_desempeno"]),
                                    puntos = reader["puntos"].ToString(),
                                    medalla = reader["medalla"].ToString(),
                                    observaciones = reader["observaciones"].ToString(),
                                    tiempo = reader["tiempo"].ToString(),
                                    ubicacion = reader["ubicacion"].ToString(),
                                    id_deportista = Convert.ToInt32(reader["id_deportista"]),
                                    id_competencia = Convert.ToInt32(reader["id_competencia"]),
                                    id_tecnico = Convert.ToInt32(reader["id_tecnico"])
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener desempenhos: " + ex.Message);
                    }
                }
            }
            return lista;
        }

        // Inserta un nuevo usuario
        public int InsertarUsuario(Usuario usuario)
        {
            int nuevoId = 0;
            using (var connection = GetConnection())
            {
                string query = @"INSERT INTO Usuarios (nombre_usuario, contrasena_hash, rol)
                                 VALUES (@NombreUsuario, @ContrasenaHash, @Rol);
                                 SELECT last_insert_rowid();";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", usuario.nombre_usuario);
                    command.Parameters.AddWithValue("@ContrasenaHash", usuario.contrasena_hash);
                    command.Parameters.AddWithValue("@Rol", usuario.rol);
                    try
                    {
                        connection.Open();
                        nuevoId = Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar usuario: " + ex.Message);
                    }
                }
            }
            return nuevoId;
        }

        // Consulta todos los usuarios
        public List<Usuario> ObtenerUsuarios()
        {
            var lista = new List<Usuario>();
            using (var connection = GetConnection())
            {
                string query = "SELECT * FROM Usuarios";
                using (var command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Usuario
                                {
                                    id_usuario = Convert.ToInt32(reader["id_usuario"]),
                                    nombre_usuario = reader["nombre_usuario"].ToString(),
                                    contrasena_hash = reader["contrasena_hash"].ToString(),
                                    rol = reader["rol"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener usuarios: " + ex.Message);
                    }
                }
            }
            return lista;
        }

        // Inserta un nuevo registro en el historial de cambios
        public int InsertarHistorialCambio(HistorialCambio cambio)
        {
            int nuevoId = 0;
            using (var connection = GetConnection())
            {
                string query = @"INSERT INTO Historial_Cambios (id_usuario, tabla_afectada, id_registro_afectado, accion, fecha_cambio)
                                 VALUES (@IdUsuario, @TablaAfectada, @IdRegistroAfectado, @Accion, @FechaCambio);
                                 SELECT last_insert_rowid();";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdUsuario", cambio.id_usuario);
                    command.Parameters.AddWithValue("@TablaAfectada", cambio.tabla_afectada);
                    command.Parameters.AddWithValue("@IdRegistroAfectado", cambio.id_registro_afectado);
                    command.Parameters.AddWithValue("@Accion", cambio.accion);
                    command.Parameters.AddWithValue("@FechaCambio", cambio.fecha_cambio);
                    try
                    {
                        connection.Open();
                        nuevoId = Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar historial de cambio: " + ex.Message);
                    }
                }
            }
            return nuevoId;
        }


        public bool InsertarRegistroDeportistaCompleto(
            Deportista deportista,
            Tecnico tecnico,
            Disciplina disciplina,
            Especialidad especialidad,
            Competencia competencia,
            Desempeno desempeno)
        {
            try
            {
                // 1. Insertar Deportista
                int idDeportista = InsertarDeportista(deportista);

                // 2. Insertar Técnico
                int idTecnico = InsertarTecnico(tecnico);

                // 3. Insertar Disciplina
                int idDisciplina = InsertarDisciplina(disciplina);

                // 4. Insertar Especialidad (requiere idDisciplina)
                especialidad.id_disciplina = idDisciplina;
                int idEspecialidad = InsertarEspecialidad(especialidad);

                // 5. Insertar Competencia (requiere idEvento y idEspecialidad)
                competencia.id_especialidad = idEspecialidad;
                int idCompetencia = InsertarCompetencia(competencia);

                // 6. Insertar Desempeño (requiere idDeportista, idCompetencia, idTecnico)
                desempeno.id_deportista = idDeportista;
                desempeno.id_competencia = idCompetencia;
                desempeno.id_tecnico = idTecnico;
                int idDesempeno = InsertarDesempeno(desempeno);

                // Si todo fue bien
                return idDeportista > 0 && idTecnico > 0 && idDisciplina > 0 && idEspecialidad > 0 && idCompetencia > 0 && idDesempeno > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<Especialidad> ObtenerEspecialidadesPorDisciplina(int idDisciplina)
        {
            var especialidades = new List<Especialidad>();
            using (var connection = GetConnection()) // Asumo que tienes un método GetConnection()
            {
                string query = "SELECT id_especialidad, nombre_especialidad, modalidad FROM Especialidades WHERE id_disciplina = @idDisciplina";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idDisciplina", idDisciplina);
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var especialidad = new Especialidad
                                {
                                    id_especialidad = Convert.ToInt32(reader["id_especialidad"]),
                                    nombre_especialidad = reader["nombre_especialidad"]?.ToString(),
                                    modalidad = reader["modalidad"]?.ToString()
                                };
                                especialidades.Add(especialidad);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener especialidades por disciplina: " + ex.Message);
                    }
                }
            }
            return especialidades;
        }

        public int ObtenerIdDisciplinaPorNombre(string nombre)
        {
            int id = 0;
            using (var connection = GetConnection())
            {
                string query = "SELECT id_disciplina FROM Disciplinas WHERE nombre_disciplina = @nombre";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);
                    try
                    {
                        connection.Open();
                        var result = command.ExecuteScalar(); // Devuelve el primer valor de la primera fila
                        if (result != null && result != DBNull.Value)
                        {
                            id = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener el ID de la disciplina: " + ex.Message);
                    }
                }
            }
            return id;
        }

        public int ObtenerIdEspecialidadPorNombre(string nombre, int idDisciplina)
        {
            int id = 0;
            using (var connection = GetConnection())
            {
                string query = "SELECT id_especialidad FROM Especialidades WHERE nombre_especialidad = @nombre AND id_disciplina = @idDisciplina";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@idDisciplina", idDisciplina);
                    try
                    {
                        connection.Open();
                        var result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            id = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener el ID de la especialidad: " + ex.Message);
                    }
                }
            }
            return id;
        }


        public int ObtenerIdTecnicoPorNombre(string nombre)
        {
            int id = 0;
            using (var connection = GetConnection())
            {
                string query = "SELECT id_tecnico FROM Tecnicos WHERE nombre_completo = @nombre";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);
                    try
                    {
                        connection.Open();
                        var result = command.ExecuteScalar(); // Devuelve el primer valor de la primera fila
                        if (result != null && result != DBNull.Value)
                        {
                            id = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener el ID de la disciplina: " + ex.Message);
                    }
                }
            }
            return id;
        }


        /// <summary>
        /// Obtiene una especialidad de la base de datos por su ID.
        /// </summary>
        public Especialidad ObtenerEspecialidadPorId(int idEspecialidad)
        {
            Especialidad especialidad = null;
            string query = "SELECT * FROM Especialidades WHERE id_especialidad = @id";

            using (SQLiteConnection connection = GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", idEspecialidad);

                    try
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                especialidad = new Especialidad
                                {
                                    id_especialidad = reader.GetInt32(reader.GetOrdinal("id_especialidad")),
                                    id_disciplina = reader.GetInt32(reader.GetOrdinal("id_disciplina")),
                                    nombre_especialidad = reader.GetString(reader.GetOrdinal("nombre_especialidad")),
                                    modalidad = reader.IsDBNull(reader.GetOrdinal("modalidad")) ? null : reader.GetString(reader.GetOrdinal("modalidad"))
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error en ObtenerEspecialidadPorId: " + ex.Message);
                    }
                }
            }
            return especialidad;
        }

        /// <summary>
        /// Busca un deportista en la base de datos por cédula, nombres o apellidos.
        /// Retorna el primer resultado encontrado.
        /// </summary>
        public Deportista BuscarDeportistaPorCedula(string cedula)
        {
            Deportista deportista = null;
            string query = "SELECT * FROM Deportistas WHERE cedula = @cedula LIMIT 1";

            using (SQLiteConnection connection = GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@cedula", cedula);

                    try
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                deportista = new Deportista
                                {
                                    id_deportista = reader.IsDBNull(reader.GetOrdinal("id_deportista")) ? 0 : reader.GetInt32(reader.GetOrdinal("id_deportista")),
                                    cedula = reader.IsDBNull(reader.GetOrdinal("cedula")) ? null : reader.GetString(reader.GetOrdinal("cedula")),
                                    nombres = reader.IsDBNull(reader.GetOrdinal("nombres")) ? null : reader.GetString(reader.GetOrdinal("nombres")),
                                    apellidos = reader.IsDBNull(reader.GetOrdinal("apellidos")) ? null : reader.GetString(reader.GetOrdinal("apellidos")),
                                    genero = reader.IsDBNull(reader.GetOrdinal("genero")) ? null : reader.GetString(reader.GetOrdinal("genero")),
                                    tipo_discapacidad = reader.IsDBNull(reader.GetOrdinal("tipo_discapacidad")) ? null : reader.GetString(reader.GetOrdinal("tipo_discapacidad"))
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error en BuscarDeportista: " + ex.Message);
                    }
                }
            }
            return deportista;
        }


        public Deportista BuscarDeportistaPorNombreCompleto(string nombres, string apellidos)
        {
            Deportista deportista = null;
            string query = "SELECT * FROM Deportistas WHERE nombres = @nombres AND apellidos = @apellidos LIMIT 1";
            using (SQLiteConnection connection = GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombres", nombres);
                    command.Parameters.AddWithValue("@apellidos", apellidos);

                    try
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                deportista = new Deportista
                                {
                                    id_deportista = reader.IsDBNull(reader.GetOrdinal("id_deportista")) ? 0 : reader.GetInt32(reader.GetOrdinal("id_deportista")),
                                    cedula = reader.IsDBNull(reader.GetOrdinal("cedula")) ? null : reader.GetString(reader.GetOrdinal("cedula")),
                                    nombres = reader.IsDBNull(reader.GetOrdinal("nombres")) ? null : reader.GetString(reader.GetOrdinal("nombres")),
                                    apellidos = reader.IsDBNull(reader.GetOrdinal("apellidos")) ? null : reader.GetString(reader.GetOrdinal("apellidos")),
                                    genero = reader.IsDBNull(reader.GetOrdinal("genero")) ? null : reader.GetString(reader.GetOrdinal("genero")),
                                    tipo_discapacidad = reader.IsDBNull(reader.GetOrdinal("tipo_discapacidad")) ? null : reader.GetString(reader.GetOrdinal("tipo_discapacidad"))
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error en BuscarDeportista: " + ex.Message);
                    }
                }
            }
            return deportista;
        }



        /// <summary>
        /// Actualiza un deportista en la base de datos usando la cédula como identificador principal.
        /// </summary>
        public bool ActualizarDeportista(Deportista deportista)
        {
            string query = "UPDATE Deportistas SET cedula = @cedula, nombres = @nombres, apellidos = @apellidos, genero = @genero, tipo_discapacidad = @discapacidad WHERE id_deportista = @id_deportista";
            int rowsAffected = 0;

            using (SQLiteConnection connection = GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_deportista", deportista.id_deportista);
                    command.Parameters.AddWithValue("@cedula", deportista.cedula);
                    command.Parameters.AddWithValue("@nombres", deportista.nombres);
                    command.Parameters.AddWithValue("@apellidos", deportista.apellidos);
                    command.Parameters.AddWithValue("@genero", deportista.genero);
                    command.Parameters.AddWithValue("@discapacidad", deportista.tipo_discapacidad);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al actualizar deportista: " + ex.Message);
                    }
                }
            }
            return rowsAffected > 0;
        }

        public List<Deportista> ObtenerDeportistasPorFiltro(string filtro, string campo)
        {
            var deportistas = new List<Deportista>();
            using (var connection = GetConnection())
            {
                string query = $"SELECT * FROM Deportistas WHERE {campo} LIKE @filtro";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@filtro", $"%{filtro}%");
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                deportistas.Add(new Deportista
                                {
                                    id_deportista = reader.GetInt32(reader.GetOrdinal("id_deportista")),
                                    cedula = reader.GetString(reader.GetOrdinal("cedula")),
                                    nombres = reader.GetString(reader.GetOrdinal("nombres")),
                                    apellidos = reader.GetString(reader.GetOrdinal("apellidos")),
                                    genero = reader.GetString(reader.GetOrdinal("genero")),
                                    tipo_discapacidad = reader.GetString(reader.GetOrdinal("tipo_discapacidad"))
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener deportistas por filtro: " + ex.Message);
                    }
                }
            }
            return deportistas;
        }


        // Obtiene una lista de todas las cédulas para el ComboBox
        public List<string> ObtenerCedulas()
        {
            var cedulas = new List<string>();
            using (var connection = GetConnection())
            {
                string query = "SELECT cedula FROM Deportistas WHERE cedula IS NOT NULL AND cedula != '' ORDER BY cedula ASC";
                using (var command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cedulas.Add(reader["cedula"].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener cédulas: " + ex.Message);
                    }
                }
            }
            return cedulas;
        }

        // Obtiene una lista de apellidos únicos y ordenados
        public List<string> ObtenerApellidosUnicos()
        {
            var apellidos = new List<string>();
            using (var connection = GetConnection())
            {
                string query = "SELECT DISTINCT apellidos FROM Deportistas ORDER BY apellidos ASC";
                using (var command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                apellidos.Add(reader["apellidos"].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener apellidos: " + ex.Message);
                    }
                }
            }
            return apellidos;
        }

        // Obtiene nombres basados en un apellido específico, ordenados
        public List<string> ObtenerNombresPorApellido(string apellido)
        {
            var nombres = new List<string>();
            using (var connection = GetConnection())
            {
                string query = "SELECT nombres FROM Deportistas WHERE apellidos = @apellido ORDER BY nombres ASC";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@apellido", apellido);
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                nombres.Add(reader["nombres"].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener nombres por apellido: " + ex.Message);
                    }
                }
            }
            return nombres;
        }



        public List<RegistroTotal> BuscarRegistrosDeportista(string whereClause, List<System.Data.SQLite.SQLiteParameter> parametros)
        {
            var lista = new List<RegistroTotal>();
            using (var connection = GetConnection())
            {
                string query = @"
                    SELECT 
                        d.id_deportista AS IdDeportista,
                        d.cedula AS Cedula,
                        d.nombres AS Nombres,
                        d.apellidos AS Apellidos,
                        d.genero AS Genero,
                        d.tipo_discapacidad AS TipoDiscapacidad,
                        t.id_tecnico AS IdTecnico,
                        t.nombre_completo AS NombreCompletoTecnico,
                        e.id_evento AS IdEvento,
                        e.nombre_evento AS NombreEvento,
                        e.lugar AS Lugar,
                        e.fecha_inicio AS FechaInicio,
                        e.fecha_fin AS FechaFin,
                        e.tipo_evento AS TipoEvento,
                        e.nivel_evento AS NivelEvento,
                        dis.id_disciplina AS IdDisciplina,
                        dis.nombre_disciplina AS NombreDisciplina,
                        esp.id_especialidad AS IdEspecialidad,
                        esp.nombre_especialidad AS NombreEspecialidad,
                        esp.modalidad AS Modalidad,
                        c.id_competencia AS IdCompetencia,
                        c.categoria AS Categoria,
                        c.division AS Division,
                        c.numero_participantes AS NumeroParticipantes,
                        c.record AS Record,
                        des.id_desempeno AS IdDesempeno,
                        des.puntos AS Puntos,
                        des.medalla AS Medalla,
                        des.observaciones AS Observaciones,
                        des.tiempo AS Tiempo,
                        des.ubicacion AS Ubicacion
                    FROM Desempeno des
                    INNER JOIN Deportistas d ON des.id_deportista = d.id_deportista
                    INNER JOIN Competencias c ON des.id_competencia = c.id_competencia
                    INNER JOIN Tecnicos t ON des.id_tecnico = t.id_tecnico
                    INNER JOIN Eventos e ON c.id_evento = e.id_evento
                    INNER JOIN Especialidades esp ON c.id_especialidad = esp.id_especialidad
                    INNER JOIN Disciplinas dis ON esp.id_disciplina = dis.id_disciplina
                ";

                // Agregar la cláusula WHERE si no está vacía
                if (!string.IsNullOrEmpty(whereClause))
                {
                    query += " WHERE " + whereClause;
                }

                query += " ORDER BY des.id_desempeno DESC";



                using (var command = new SQLiteCommand(query, connection))
                {
                    // Agregar los parámetros a la consulta
                    if (parametros != null)
                    {
                        command.Parameters.AddRange(parametros.ToArray());
                    }

                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var registro = new RegistroTotal
                                {
                                    IdDeportista = reader["IdDeportista"] != DBNull.Value ? Convert.ToInt32(reader["IdDeportista"]) : 0,
                                    Cedula = reader["Cedula"]?.ToString(),
                                    Nombres = reader["Nombres"]?.ToString(),
                                    Apellidos = reader["Apellidos"]?.ToString(),
                                    Genero = reader["Genero"]?.ToString(),
                                    TipoDiscapacidad = reader["TipoDiscapacidad"]?.ToString(),
                                    IdTecnico = reader["IdTecnico"] != DBNull.Value ? Convert.ToInt32(reader["IdTecnico"]) : 0,
                                    NombreCompletoTecnico = reader["NombreCompletoTecnico"]?.ToString(),
                                    IdEvento = reader["IdEvento"] != DBNull.Value ? Convert.ToInt32(reader["IdEvento"]) : 0,
                                    NombreEvento = reader["NombreEvento"]?.ToString(),
                                    Lugar = reader["Lugar"]?.ToString(),
                                    FechaInicio = reader["FechaInicio"]?.ToString(),
                                    FechaFin = reader["FechaFin"]?.ToString(),
                                    TipoEvento = reader["TipoEvento"]?.ToString(),
                                    NivelEvento = reader["NivelEvento"]?.ToString(),
                                    IdDisciplina = reader["IdDisciplina"] != DBNull.Value ? Convert.ToInt32(reader["IdDisciplina"]) : 0,
                                    NombreDisciplina = reader["NombreDisciplina"]?.ToString(),
                                    IdEspecialidad = reader["IdEspecialidad"] != DBNull.Value ? Convert.ToInt32(reader["IdEspecialidad"]) : 0,
                                    NombreEspecialidad = reader["NombreEspecialidad"]?.ToString(),
                                    Modalidad = reader["Modalidad"]?.ToString(),
                                    IdCompetencia = reader["IdCompetencia"] != DBNull.Value ? Convert.ToInt32(reader["IdCompetencia"]) : 0,
                                    Categoria = reader["Categoria"]?.ToString(),
                                    Division = reader["Division"]?.ToString(),
                                    NumeroParticipantes = reader["NumeroParticipantes"]?.ToString(),
                                    Record = reader["Record"]?.ToString(),
                                    IdDesempeno = reader["IdDesempeno"] != DBNull.Value ? Convert.ToInt32(reader["IdDesempeno"]) : 0,
                                    Puntos = reader["Puntos"]?.ToString(),
                                    Medalla = reader["Medalla"]?.ToString(),
                                    Observaciones = reader["Observaciones"]?.ToString(),
                                    Tiempo = reader["Tiempo"]?.ToString(),
                                    Ubicacion = reader["Ubicacion"]?.ToString()
                                };
                                lista.Add(registro);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener registros completos: " + ex.Message);
                    }
                }
            }
            return lista;
        }

        public List<RegistroTotal> BuscarRegistrosDeportistaFiltrado(string whereClause, List<System.Data.SQLite.SQLiteParameter> parametros, string orderByClause)
        {
            var lista = new List<RegistroTotal>();
            using (var connection = GetConnection())
            {
                string query = @"
                    SELECT 
                        d.id_deportista AS IdDeportista,
                        d.cedula AS Cedula,
                        d.nombres AS Nombres,
                        d.apellidos AS Apellidos,
                        d.genero AS Genero,
                        d.tipo_discapacidad AS TipoDiscapacidad,
                        t.id_tecnico AS IdTecnico,
                        t.nombre_completo AS NombreCompletoTecnico,
                        e.id_evento AS IdEvento,
                        e.nombre_evento AS NombreEvento,
                        e.lugar AS Lugar,
                        e.fecha_inicio AS FechaInicio,
                        e.fecha_fin AS FechaFin,
                        e.tipo_evento AS TipoEvento,
                        e.nivel_evento AS NivelEvento,
                        dis.id_disciplina AS IdDisciplina,
                        dis.nombre_disciplina AS NombreDisciplina,
                        esp.id_especialidad AS IdEspecialidad,
                        esp.nombre_especialidad AS NombreEspecialidad,
                        esp.modalidad AS Modalidad,
                        c.id_competencia AS IdCompetencia,
                        c.categoria AS Categoria,
                        c.division AS Division,
                        c.numero_participantes AS NumeroParticipantes,
                        c.record AS Record,
                        des.id_desempeno AS IdDesempeno,
                        des.puntos AS Puntos,
                        des.medalla AS Medalla,
                        des.observaciones AS Observaciones,
                        des.tiempo AS Tiempo,
                        des.ubicacion AS Ubicacion
                    FROM Desempeno des
                    INNER JOIN Deportistas d ON des.id_deportista = d.id_deportista
                    INNER JOIN Competencias c ON des.id_competencia = c.id_competencia
                    INNER JOIN Tecnicos t ON des.id_tecnico = t.id_tecnico
                    INNER JOIN Eventos e ON c.id_evento = e.id_evento
                    INNER JOIN Especialidades esp ON c.id_especialidad = esp.id_especialidad
                    INNER JOIN Disciplinas dis ON esp.id_disciplina = dis.id_disciplina
                ";

                // Añadir la cláusula WHERE si existe.
                if (!string.IsNullOrEmpty(whereClause))
                {
                    query += " WHERE " + whereClause;
                }

                // Añadir la cláusula ORDER BY si existe.
                if (!string.IsNullOrEmpty(orderByClause))
                {
                    query += " " + orderByClause;
                }



                using (var command = new SQLiteCommand(query, connection))
                {
                    // Agregar los parámetros a la consulta de forma segura.
                    if (parametros != null && parametros.Any())
                    {
                        command.Parameters.AddRange(parametros.ToArray());
                    }

                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var registro = new RegistroTotal
                                {
                                    IdDeportista = reader["IdDeportista"] != DBNull.Value ? Convert.ToInt32(reader["IdDeportista"]) : 0,
                                    Cedula = reader["Cedula"]?.ToString(),
                                    Nombres = reader["Nombres"]?.ToString(),
                                    Apellidos = reader["Apellidos"]?.ToString(),
                                    Genero = reader["Genero"]?.ToString(),
                                    TipoDiscapacidad = reader["TipoDiscapacidad"]?.ToString(),
                                    IdTecnico = reader["IdTecnico"] != DBNull.Value ? Convert.ToInt32(reader["IdTecnico"]) : 0,
                                    NombreCompletoTecnico = reader["NombreCompletoTecnico"]?.ToString(),
                                    IdEvento = reader["IdEvento"] != DBNull.Value ? Convert.ToInt32(reader["IdEvento"]) : 0,
                                    NombreEvento = reader["NombreEvento"]?.ToString(),
                                    Lugar = reader["Lugar"]?.ToString(),
                                    FechaInicio = reader["FechaInicio"]?.ToString(),
                                    FechaFin = reader["FechaFin"]?.ToString(),
                                    TipoEvento = reader["TipoEvento"]?.ToString(),
                                    NivelEvento = reader["NivelEvento"]?.ToString(),
                                    IdDisciplina = reader["IdDisciplina"] != DBNull.Value ? Convert.ToInt32(reader["IdDisciplina"]) : 0,
                                    NombreDisciplina = reader["NombreDisciplina"]?.ToString(),
                                    IdEspecialidad = reader["IdEspecialidad"] != DBNull.Value ? Convert.ToInt32(reader["IdEspecialidad"]) : 0,
                                    NombreEspecialidad = reader["NombreEspecialidad"]?.ToString(),
                                    Modalidad = reader["Modalidad"]?.ToString(),
                                    IdCompetencia = reader["IdCompetencia"] != DBNull.Value ? Convert.ToInt32(reader["IdCompetencia"]) : 0,
                                    Categoria = reader["Categoria"]?.ToString(),
                                    Division = reader["Division"]?.ToString(),
                                    NumeroParticipantes = reader["NumeroParticipantes"]?.ToString(),
                                    Record = reader["Record"]?.ToString(),
                                    IdDesempeno = reader["IdDesempeno"] != DBNull.Value ? Convert.ToInt32(reader["IdDesempeno"]) : 0,
                                    Puntos = reader["Puntos"]?.ToString(),
                                    Medalla = reader["Medalla"]?.ToString(),
                                    Observaciones = reader["Observaciones"]?.ToString(),
                                    Tiempo = reader["Tiempo"]?.ToString(),
                                    Ubicacion = reader["Ubicacion"]?.ToString()
                                };
                                lista.Add(registro);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener registros completos: " + ex.Message);
                    }
                }
            }
            return lista;
        }


        // Consulta la competencia especifica
        public int BuscarIdCompetenciaExacta(string categoria, string division, string participantes, string record, int idEvento, int especialidadId)
        {
            int idCompetencia = 0; // Valor por defecto si no se encuentra

            using (var connection = GetConnection())
            {
                string query = @"
            SELECT id_competencia FROM Competencias
            WHERE categoria = @categoria AND
                  division = @division AND
                  numero_participantes = @participantes AND
                  record = @record AND
                  id_evento = @idEvento AND
                  id_especialidad = @especialidadId";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@categoria", categoria);
                    command.Parameters.AddWithValue("@division", division);
                    command.Parameters.AddWithValue("@participantes", participantes);
                    command.Parameters.AddWithValue("@record", record);
                    command.Parameters.AddWithValue("@idEvento", idEvento);
                    command.Parameters.AddWithValue("@especialidadId", especialidadId);

                    try
                    {
                        connection.Open();
                        var result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            idCompetencia = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener el ID de la competencia: " + ex.Message);
                    }
                }
            }
            return idCompetencia;
        }


        /// <summary>
        /// Actualiza un registro de la tabla Eventos usando el id_evento del objeto.
        /// Retorna true si se actualizó al menos una fila.
        /// </summary>
        public bool ActualizarEvento(Evento evento)
        {
            if (evento == null) return false;

            int rowsAffected = 0;
            using (var connection = GetConnection())
            {
                string query = @"
            UPDATE Eventos
            SET nombre_evento = @NombreEvento,
                lugar = @Lugar,
                fecha_inicio = @FechaInicio,
                fecha_fin = @FechaFin,
                tipo_evento = @TipoEvento,
                nivel_evento = @NivelEvento
            WHERE id_evento = @IdEvento;
        ";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreEvento", evento.nombre_evento ?? string.Empty);
                    command.Parameters.AddWithValue("@Lugar", evento.lugar ?? string.Empty);
                    command.Parameters.AddWithValue("@FechaInicio", evento.fecha_inicio ?? string.Empty);
                    command.Parameters.AddWithValue("@FechaFin", evento.fecha_fin ?? string.Empty);
                    command.Parameters.AddWithValue("@TipoEvento", evento.tipo_evento ?? string.Empty);
                    command.Parameters.AddWithValue("@NivelEvento", evento.nivel_evento ?? string.Empty);
                    command.Parameters.AddWithValue("@IdEvento", evento.id_evento);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Log en consola; en producción puedes usar un logger
                        Console.WriteLine("Error al actualizar evento: " + ex.Message);
                    }
                }
            }
            return rowsAffected > 0;
        }


        /// <summary>
        /// Actualiza un registro de la tabla 'desempeno' usando los valores del objeto Desempeno.
        /// Devuelve true si se afectó al menos una fila.
        /// </summary>
        public bool ActualizarDesempeno(Desempeno d)
        {
            if (d == null) throw new ArgumentNullException(nameof(d));
            if (d.id_desempeno <= 0) throw new ArgumentException("El id_desempeno debe ser mayor que 0.", nameof(d));

            // SQL parametrizado para evitar inyección y problemas de formato
            const string sql = @"
            UPDATE desempeno
            SET
                puntos         = @puntos,
                medalla        = @medalla,
                observaciones  = @observaciones,
                tiempo         = @tiempo,
                ubicacion      = @ubicacion,
                id_deportista  = @id_deportista,
                id_competencia = @id_competencia,
                id_tecnico     = @id_tecnico
            WHERE id_desempeno = @id_desempeno;
        ";

            // ---- Ajusta esto si tu DbService guarda la cadena de conexión de otra forma ----
            // Ejemplo típico: existe un campo privado _connectionString en DbService
            string connStr = GetConnectionString(); // si tu clase tiene un método así; si no, usa el campo existente

            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();

                using (var tran = conn.BeginTransaction())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    // Parametrizamos (si algún campo puede ser nulo, asignamos DBNull.Value)
                    cmd.Parameters.AddWithValue("@puntos", (object)d.puntos ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@medalla", (object)d.medalla ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@observaciones", (object)d.observaciones ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@tiempo", (object)d.tiempo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ubicacion", (object)d.ubicacion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_deportista", d.id_deportista);
                    cmd.Parameters.AddWithValue("@id_competencia", d.id_competencia);
                    cmd.Parameters.AddWithValue("@id_tecnico", d.id_tecnico);
                    cmd.Parameters.AddWithValue("@id_desempeno", d.id_desempeno);

                    int filas = cmd.ExecuteNonQuery();
                    tran.Commit();

                    return filas > 0;
                }
            }
        }

        // Ejemplo auxiliar: si tu clase NO tiene GetConnectionString, reemplaza este método por el acceso real a la cadena
        private string GetConnectionString()
        {
            // Si DbService ya tiene un campo o propiedad con la cadena, usa ese en lugar de construirla.
            // Ejemplo usando una ruta relativa (ajusta según tu proyecto):
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = System.IO.Path.Combine(baseDir, @"..\..\..\FDCH.Datos\Archivos\BDCompetencias.db");
            string fullPath = System.IO.Path.GetFullPath(relativePath);
            return $"Data Source={fullPath};Version=3;";
        }




        // Obtiene todos los registros del historial
        public List<HistorialCambio> ObtenerHistorialCambios()
        {
            var lista = new List<HistorialCambio>();
            using (var connection = GetConnection())
            {
                string query = "SELECT * FROM Historial_Cambios ORDER BY id_log DESC";
                using (var command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new HistorialCambio
                            {
                                // Manejo de nulos para id_log
                                id_log = reader.IsDBNull(reader.GetOrdinal("id_log")) ? 0 : Convert.ToInt32(reader["id_log"]),
                                // Manejo de nulos para id_usuario
                                id_usuario = reader.IsDBNull(reader.GetOrdinal("id_usuario")) ? 0 : Convert.ToInt32(reader["id_usuario"]),
                                // Manejo de nulos para tabla_afectada
                                tabla_afectada = reader.IsDBNull(reader.GetOrdinal("tabla_afectada")) ? string.Empty : reader["tabla_afectada"].ToString(),
                                // Manejo de nulos para id_registro_afectado
                                id_registro_afectado = reader.IsDBNull(reader.GetOrdinal("id_registro_afectado")) ? 0 : Convert.ToInt32(reader["id_registro_afectado"]),
                                // Manejo de nulos para accion
                                accion = reader.IsDBNull(reader.GetOrdinal("accion")) ? string.Empty : reader["accion"].ToString(),
                                // Manejo de nulos para fecha_cambio
                                fecha_cambio = reader.IsDBNull(reader.GetOrdinal("fecha_cambio")) ? string.Empty : reader["fecha_cambio"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // Métodos de ayuda para obtener nombres
        public string ObtenerNombreDeportistaPorId(int id)
        {
            string nombre = "N/A";
            using (var connection = GetConnection())
            {
                string query = "SELECT nombres, apellidos FROM Deportistas WHERE id_deportista = @id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Validar cada campo antes de usarlo
                            var nombres = reader["nombres"] != DBNull.Value ? reader["nombres"].ToString() : string.Empty;
                            var apellidos = reader["apellidos"] != DBNull.Value ? reader["apellidos"].ToString() : string.Empty;

                            // Construir el nombre completo, omitiendo espacios si un campo está vacío
                            nombre = $"{nombres.Trim()} {apellidos.Trim()}".Trim();

                            // Si ambos están vacíos, mantener el valor por defecto "N/A"
                            if (string.IsNullOrEmpty(nombre))
                            {
                                nombre = "N/A";
                            }
                        }
                    }
                }
            }
            return nombre;
        }

        
        public string ObtenerNombreTecnicoPorId(int id)
        {
            string nombre = "N/A";
            using (var connection = GetConnection())
            {
                string query = "SELECT nombre_completo FROM Tecnicos WHERE id_tecnico = @id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        nombre = result.ToString();
                    }
                }
            }
            return nombre;
        }

        public string ObtenerNombreUsuarioPorId(int id)
        {
            string nombre = "N/A";
            using (var connection = GetConnection())
            {
                string query = "SELECT nombre_usuario FROM Usuarios WHERE id_usuario = @id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        nombre = result.ToString();
                    }
                }
            }
            return nombre;
        }


        public string ObtenerNombreEventoPorId(int id)
        {
            string nombre = "N/A";
            using (var connection = GetConnection())
            {
                string query = "SELECT nombre_evento FROM Eventos WHERE id_evento = @id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        nombre = result.ToString();
                    }
                }
            }
            return nombre;
        }

        public string ObtenerNombreDisciplinaPorId(int id)
        {
            string nombre = "N/A";
            using (var connection = GetConnection())
            {
                string query = "SELECT nombre_disciplina FROM Disciplinas WHERE id_disciplina = @id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        nombre = result.ToString();
                    }
                }
            }
            return nombre;
        }

        public string ObtenerNombreEspecialidadPorId(int id)
        {
            string nombre = "N/A";
            using (var connection = GetConnection())
            {
                string query = "SELECT nombre_especialidad FROM Especialidades WHERE id_especialidad = @id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        nombre = result.ToString();
                    }
                }
            }
            return nombre;
        }

        public string ObtenerNombreCompetenciaPorId(int id)
        {
            string nombre = "N/A";
            using (var connection = GetConnection())
            {
                string query = "SELECT categoria, division FROM Competencias WHERE id_competencia = @id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Validar cada campo
                            var categoria = reader["categoria"] != DBNull.Value ? reader["categoria"].ToString() : "Sin categoría";
                            var division = reader["division"] != DBNull.Value ? reader["division"].ToString() : "Sin división";

                            nombre = $"Categoría: {categoria}, División: {division}";
                        }
                    }
                }
            }
            return nombre;
        }

        public string ObtenerNombreDesempenoPorId(int id)
        {
            string nombre = "N/A";
            using (var connection = GetConnection())
            {
                string query = "SELECT puntos, tiempo, ubicacion FROM Desempeno WHERE id_desempeno = @id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Validar cada campo
                            var puntos = reader["puntos"] != DBNull.Value ? reader["puntos"].ToString() : "N/A";
                            var tiempo = reader["tiempo"] != DBNull.Value ? reader["tiempo"].ToString() : "N/A";
                            var ubicacion = reader["ubicacion"] != DBNull.Value ? reader["ubicacion"].ToString() : "N/A";

                            nombre = $"Puntos: {puntos}, Tiempo: {tiempo}, Ubicación: {ubicacion}";
                        }
                    }
                }
            }
            return nombre;
        }


        /// <summary>
        /// Obtiene el registro del Director (se espera un único registro).
        /// Retorna null si no existe ningún registro en la tabla Director.
        /// </summary>
        public Director ObtenerDirector()
        {
            Director director = null;

            using (SQLiteConnection connection = GetConnection())
            {
                string sql = "SELECT id_director, titulo, cargo FROM Director LIMIT 1;";
                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                director = new Director
                                {
                                    id_director = Convert.ToInt32(reader["id_director"]),
                                    titulo = reader["titulo"]?.ToString(),
                                    // columna "cargo" mapeada a la propiedad "rol" en tu entidad
                                    rol = reader["cargo"]?.ToString()
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log (console por ahora). Puedes sustituirlo por tu sistema de logs.
                        Console.WriteLine("Error en ObtenerDirector: " + ex.Message);
                    }
                }
            }

            return director;
        }

        /// <summary>
        /// Actualiza el registro del Director. Si no existe registro con el id proporcionado,
        /// intenta insertar uno nuevo (comportamiento "upsert" sencillo).
        /// Devuelve true si la operación (update o insert) tuvo efecto.
        /// </summary>
        public bool ActualizarDirector(Director director)
        {
            if (director == null) throw new ArgumentNullException(nameof(director));

            using (SQLiteConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();

                    // Si el id_director está definido y > 0 intentamos UPDATE primero
                    if (director.id_director > 0)
                    {
                        string updateSql = @"UPDATE Director 
                                     SET titulo = @titulo, cargo = @cargo
                                     WHERE id_director = @id_director;";
                        using (var cmd = new SQLiteCommand(updateSql, connection))
                        {
                            cmd.Parameters.AddWithValue("@titulo", director.titulo ?? string.Empty);
                            cmd.Parameters.AddWithValue("@cargo", director.rol ?? string.Empty);
                            cmd.Parameters.AddWithValue("@id_director", director.id_director);

                            int rows = cmd.ExecuteNonQuery();
                            if (rows > 0) return true;
                            // si rows == 0, caerá a la inserción más abajo
                        }
                    }

                    // Si no había id o el UPDATE no afectó filas, hacemos INSERT
                    string insertSql = @"INSERT INTO Director (titulo, cargo) VALUES (@titulo, @cargo);
                                 SELECT last_insert_rowid();";
                    using (var cmdInsert = new SQLiteCommand(insertSql, connection))
                    {
                        cmdInsert.Parameters.AddWithValue("@titulo", director.titulo ?? string.Empty);
                        cmdInsert.Parameters.AddWithValue("@cargo", director.rol ?? string.Empty);

                        object result = cmdInsert.ExecuteScalar();
                        if (result != null)
                        {
                            // actualizar el id en el objeto (opcional)
                            director.id_director = Convert.ToInt32(result);
                            return true;
                        }
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en ActualizarDirector: " + ex.Message);
                    return false;
                }
            }
        }


        public Dictionary<int, List<string>> ObtenerDisciplinasPorDeportista()
        {
            var resultado = new Dictionary<int, List<string>>();

            using (var conn = GetConnection())
            {
                conn.Open();

                // Consulta que junta Desempeño -> Competencias -> Especialidades -> Disciplinas
                // y devuelve pares (id_deportista, nombre_disciplina).
                // LEFT JOINs para no perder deportistas sin registros.
                string sql = @"
            SELECT d.id_deportista AS id_deportista, di.nombre_disciplina AS nombre_disciplina
            FROM Deportistas d
            LEFT JOIN Desempeno ds ON ds.id_deportista = d.id_deportista
            LEFT JOIN Competencias c ON c.id_competencia = ds.id_competencia
            LEFT JOIN Especialidades e ON e.id_especialidad = c.id_especialidad
            LEFT JOIN Disciplinas di ON di.id_disciplina = e.id_disciplina
            WHERE di.nombre_disciplina IS NOT NULL
            ORDER BY d.id_deportista, di.nombre_disciplina;
        ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader["id_deportista"]);
                                string disciplina = reader.IsDBNull(1) ? null : reader["nombre_disciplina"].ToString();

                                if (id == 0 || string.IsNullOrWhiteSpace(disciplina)) continue;

                                if (!resultado.ContainsKey(id))
                                    resultado[id] = new List<string>();

                                // Evitar duplicados repetidos
                                if (!resultado[id].Contains(disciplina))
                                    resultado[id].Add(disciplina);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Loguea o muestra según tu estrategia; no lanzar para no romper UI inesperadamente.
                        Console.WriteLine("Error en ObtenerDisciplinasPorDeportista: " + ex.Message);
                    }
                }
            }

            return resultado;
        }

        /*/// <summary>
        /// Realiza la fusión de deportistas de forma transaccional y registra acciones en Historial_Cambios.
        /// - Actualiza el deportista objetivo con los datos fusionados.
        /// - Reasigna Desempeno de los ids a eliminar al targetId.
        /// - Elimina los deportistas en idsAEliminar.
        /// - Inserta registros en Historial_Cambios (una fila por actualización/elim.).
        /// idUsuario puede ser null, en cuyo caso se insertará NULL en la tabla historial.
        /// </summary>
        public bool FusionarDeportistasTransaction(Deportista deportistaFusionado, List<int> idsAEliminar, int? idUsuario = null)
        {
            if (deportistaFusionado == null) throw new ArgumentNullException(nameof(deportistaFusionado));

            int targetId = deportistaFusionado.id_deportista;
            var ids = (idsAEliminar ?? new List<int>()).Where(x => x != targetId).Distinct().ToList();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1) Update deportista objetivo
                        string sqlUpdateDeportista = @"
                    UPDATE Deportistas
                    SET cedula = @Cedula,
                        nombres = @Nombres,
                        apellidos = @Apellidos,
                        genero = @Genero,
                        tipo_discapacidad = @TipoDiscapacidad
                    WHERE id_deportista = @IdDeportista;
                ";
                        using (var cmd = new SQLiteCommand(sqlUpdateDeportista, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Cedula", (object)deportistaFusionado.cedula ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Nombres", (object)deportistaFusionado.nombres ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Apellidos", (object)deportistaFusionado.apellidos ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Genero", (object)deportistaFusionado.genero ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@TipoDiscapacidad", (object)deportistaFusionado.tipo_discapacidad ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@IdDeportista", targetId);
                            cmd.ExecuteNonQuery();
                        }

                        // Registrar en Historial_Cambios la actualización del target
                        string insertHistSql = @"
                    INSERT INTO Historial_Cambios (id_usuario, tabla_afectada, id_registro_afectado, accion, fecha_cambio)
                    VALUES (@IdUsuario, @Tabla, @IdRegistro, @Accion, @Fecha);
                ";
                        using (var cmdHist = new SQLiteCommand(insertHistSql, connection, transaction))
                        {
                            cmdHist.Parameters.AddWithValue("@IdUsuario", idUsuario.HasValue ? (object)idUsuario.Value : DBNull.Value);
                            cmdHist.Parameters.AddWithValue("@Tabla", "Deportistas");
                            cmdHist.Parameters.AddWithValue("@IdRegistro", targetId);
                            cmdHist.Parameters.AddWithValue("@Accion", "FUSION DEPORTISTAS");
                            cmdHist.Parameters.AddWithValue("@Fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmdHist.ExecuteNonQuery();
                        }

                        if (ids.Count > 0)
                        {
                            // Preparar parámetros IN (@id0,@id1,...)
                            var inParams = new List<string>();
                            for (int i = 0; i < ids.Count; i++) inParams.Add($"@id{i}");
                            string whereIn = string.Join(",", inParams);

                            // 2) Reasignar Desempeno -> set target where in (...)
                            string sqlUpdateDesempeno = $"UPDATE Desempeno SET id_deportista = @TargetId WHERE id_deportista IN ({whereIn});";
                            using (var cmdUpdDes = new SQLiteCommand(sqlUpdateDesempeno, connection, transaction))
                            {
                                cmdUpdDes.Parameters.AddWithValue("@TargetId", targetId);
                                for (int i = 0; i < ids.Count; i++) cmdUpdDes.Parameters.AddWithValue(inParams[i], ids[i]);
                                cmdUpdDes.ExecuteNonQuery();
                            }

                            // Registrar en Historial_Cambios la reasignación para cada id eliminado (opcionalmente podrías registrar cada desempeño,
                            // pero registrar que se reasignaron desempeños por cada deportista eliminado es suficiente)
                            using (var cmdHist = new SQLiteCommand(insertHistSql, connection, transaction))
                            {
                                // Preparametros fijos
                                cmdHist.Parameters.Add(new SQLiteParameter("@IdUsuario", idUsuario.HasValue ? (object)idUsuario.Value : DBNull.Value));
                                cmdHist.Parameters.Add(new SQLiteParameter("@Tabla", "Desempeno"));
                                cmdHist.Parameters.Add(new SQLiteParameter("@IdRegistro", 0)); // cambiar luego por id concreto si quieres
                                cmdHist.Parameters.Add(new SQLiteParameter("@Accion", "REASIGNAMIENTO POR FUSÌON"));
                                cmdHist.Parameters.Add(new SQLiteParameter("@Fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                                // Para evitar re-preparar la sentencia cada vez con nombres distintos, ejecutamos por cada id:
                                for (int i = 0; i < ids.Count; i++)
                                {
                                    cmdHist.Parameters["@IdRegistro"].Value = ids[i]; // id_registro_afectado = deportista eliminado
                                    cmdHist.ExecuteNonQuery();
                                }
                            }

                            // 3) Eliminar deportistas (los idsToRemove)
                            string sqlDelete = $"DELETE FROM Deportistas WHERE id_deportista IN ({whereIn});";
                            using (var cmdDel = new SQLiteCommand(sqlDelete, connection, transaction))
                            {
                                for (int i = 0; i < ids.Count; i++) cmdDel.Parameters.AddWithValue(inParams[i], ids[i]);
                                cmdDel.ExecuteNonQuery();
                            }

                            // Registrar eliminaciones en Historial_Cambios por cada deportista eliminado
                            using (var cmdHist = new SQLiteCommand(insertHistSql, connection, transaction))
                            {
                                cmdHist.Parameters.Add(new SQLiteParameter("@IdUsuario", idUsuario.HasValue ? (object)idUsuario.Value : DBNull.Value));
                                cmdHist.Parameters.Add(new SQLiteParameter("@Tabla", "Deportistas"));
                                cmdHist.Parameters.Add(new SQLiteParameter("@IdRegistro", 0));
                                cmdHist.Parameters.Add(new SQLiteParameter("@Accion", "ELIMINACION POR FUSION"));
                                cmdHist.Parameters.Add(new SQLiteParameter("@Fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                                for (int i = 0; i < ids.Count; i++)
                                {
                                    cmdHist.Parameters["@IdRegistro"].Value = ids[i];
                                    cmdHist.ExecuteNonQuery();
                                }
                            }
                        }

                        // Si llegamos hasta aquí todo está bien -> Commit
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        try { transaction.Rollback(); } catch { }
                        Console.WriteLine("Error FusionarDeportistasTransaction: " + ex.Message);
                        return false;
                    }
                }
            }
        }
         */

        /*public bool ActualizarIdDesempenoPorDeportista(int oldId, int newId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "UPDATE Desempeno SET id_deportista = @newId WHERE id_deportista = @oldId";
                        using (var cmd = new SQLiteCommand(sql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@newId", newId);
                            cmd.Parameters.AddWithValue("@oldId", oldId);
                            cmd.ExecuteNonQuery();
                        }
                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error en ActualizarIdDesempenoPorDeportista: " + ex.Message);
                        try { tran.Rollback(); } catch { }
                        return false;
                    }
                }
            }
        }

        public bool EliminarDeportistaPorId(int idDeportista)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "DELETE FROM Deportistas WHERE id_deportista = @id";
                        using (var cmd = new SQLiteCommand(sql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@id", idDeportista);
                            cmd.ExecuteNonQuery();
                        }
                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error en EliminarDeportistaPorId: " + ex.Message);
                        try { tran.Rollback(); } catch { }
                        return false;
                    }
                }
            }
        }*/

        /// <summary>
        /// Inserta un registro en Historial_Cambios.
        /// </summary>
        public bool InsertarHistorialCambio(int idUsuario, string tabla, int idRegistro, string accion, string fecha)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                try
                {
                    string sql = "INSERT INTO Historial_Cambios (id_usuario, tabla_afectada, id_registro_afectado, accion, fecha_cambio) " +
                                 "VALUES (@idUsuario, @tabla, @idRegistro, @accion, @fecha)";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario == 0 ? (object)DBNull.Value : idUsuario);
                        cmd.Parameters.AddWithValue("@tabla", tabla ?? "");
                        cmd.Parameters.AddWithValue("@idRegistro", idRegistro);
                        cmd.Parameters.AddWithValue("@accion", accion ?? "");
                        cmd.Parameters.AddWithValue("@fecha", fecha ?? DateTime.UtcNow.ToString("o"));
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en InsertarHistorialCambio: " + ex.Message);
                    return false;
                }
            }
        }


        /// <summary>
        /// Fusiona deportistas creando un nuevo deportista con los datos en 'nuevo',
        /// reasigna desempeños de los ids en idsAntiguos al nuevoId, elimina los deportistas antiguos
        /// y, una vez exitoso el commit, registra una sola entrada en Historial_Cambios usando
        /// el método InsertarHistorialCambio(int idUsuario, string tabla, int idRegistro, string accion, string fecha).
        /// Devuelve true si todo fue exitoso y devuelve el nuevoId por out.
        /// </summary>
        public bool FusionarDeportistas(List<int> idsAntiguos, Deportista nuevo, int idUsuarioQueHaceLaAccion, out int nuevoId)
        {
            nuevoId = 0;

            if (nuevo == null) return false;
            if (idsAntiguos == null || idsAntiguos.Count == 0) return false;

            // Normalizar la lista: eliminar ceros y duplicados
            var ids = idsAntiguos.Where(x => x > 0).Distinct().ToList();
            if (ids.Count == 0) return false;

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1) Insertar nuevo deportista y obtener nuevoId
                        string insertSql = @"
                    INSERT INTO Deportistas (cedula, nombres, apellidos, genero, tipo_discapacidad)
                    VALUES (@cedula, @nombres, @apellidos, @genero, @tipo_discapacidad);
                    SELECT last_insert_rowid();
                ";

                        using (var cmdIns = new SQLiteCommand(insertSql, conn, tran))
                        {
                            cmdIns.Parameters.AddWithValue("@cedula", (object)nuevo.cedula ?? DBNull.Value);
                            cmdIns.Parameters.AddWithValue("@nombres", (object)nuevo.nombres ?? DBNull.Value);
                            cmdIns.Parameters.AddWithValue("@apellidos", (object)nuevo.apellidos ?? DBNull.Value);
                            cmdIns.Parameters.AddWithValue("@genero", (object)nuevo.genero ?? DBNull.Value);
                            cmdIns.Parameters.AddWithValue("@tipo_discapacidad", (object)nuevo.tipo_discapacidad ?? DBNull.Value);

                            object scalar = cmdIns.ExecuteScalar();
                            if (scalar == null) throw new Exception("No se obtuvo id del nuevo deportista.");
                            nuevoId = Convert.ToInt32(scalar);
                        }

                        // 2) Reasignar desempeños: UPDATE Desempeno SET id_deportista = nuevoId WHERE id_deportista = old
                        string updateDesSql = @"UPDATE Desempeno SET id_deportista = @nuevoId WHERE id_deportista = @oldId;";

                        using (var cmdUpd = new SQLiteCommand(updateDesSql, conn, tran))
                        {
                            // Crear parámetros explícitos (no usar Add(...) que devuelve índice)
                            var pNuevo = new SQLiteParameter("@nuevoId", System.Data.DbType.Int32) { Value = nuevoId };
                            var pOld = new SQLiteParameter("@oldId", System.Data.DbType.Int32) { Value = 0 }; // valor inicial
                            cmdUpd.Parameters.Add(pNuevo);
                            cmdUpd.Parameters.Add(pOld);

                            foreach (var oldId in ids)
                            {
                                if (oldId == nuevoId) continue; // por seguridad
                                pOld.Value = oldId;
                                cmdUpd.ExecuteNonQuery();
                            }
                        }

                        // 3) Eliminar deportistas antiguos (excepto si alguno coincide con nuevoId)
                        string deleteSql = @"DELETE FROM Deportistas WHERE id_deportista = @id;";

                        using (var cmdDel = new SQLiteCommand(deleteSql, conn, tran))
                        {
                            var pDel = new SQLiteParameter("@id", System.Data.DbType.Int32) { Value = 0 };
                            cmdDel.Parameters.Add(pDel);

                            foreach (var oldId in ids)
                            {
                                if (oldId == nuevoId) continue;
                                pDel.Value = oldId;
                                cmdDel.ExecuteNonQuery();
                            }
                        }

                        // 4) Commit de la transacción
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        try { tran.Rollback(); } catch { /* ignorar */ }
                        Console.WriteLine("Error en FusionarDeportistas (transacción): " + ex.Message);
                        nuevoId = 0;
                        return false;
                    }
                }
            }

            // 5) Registrar en historial (fuera de la transacción, usando tu método existente)
            try
            {
                string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                bool histOk = InsertarHistorialCambio(idUsuarioQueHaceLaAccion == 0 ? 0 : idUsuarioQueHaceLaAccion,
                                                      "Deportistas", nuevoId, "DEPORTISTA FUSIONADO", fecha);
                if (!histOk)
                {
                    Console.WriteLine("Advertencia: no se pudo insertar registro en Historial_Cambios tras la fusión.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error insertando historial después de FusionarDeportistas: " + ex.Message);
            }

            return nuevoId != 0;
        }

        //Nuevo método para insertar en el historial que se usa en la operacion de separar deportistas
        private bool InsertarHistorialCambioEnTransaccion(SQLiteConnection conn, SQLiteTransaction tran, int idUsuario, string tabla, int idRegistro, string accion, string fecha)
        {
            if (conn == null) throw new ArgumentNullException(nameof(conn));
            if (tran == null) throw new ArgumentNullException(nameof(tran));

            try
            {
                string sql = "INSERT INTO Historial_Cambios (id_usuario, tabla_afectada, id_registro_afectado, accion, fecha_cambio) " +
                             "VALUES (@idUsuario, @tabla, @idRegistro, @accion, @fecha);";

                using (var cmd = new SQLiteCommand(sql, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario == 0 ? (object)DBNull.Value : idUsuario);
                    cmd.Parameters.AddWithValue("@tabla", tabla ?? "");
                    cmd.Parameters.AddWithValue("@idRegistro", idRegistro);
                    cmd.Parameters.AddWithValue("@accion", accion ?? "");
                    cmd.Parameters.AddWithValue("@fecha", fecha ?? DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                // Log para depuración; no se traga la excepción aquí para que el llamador decida
                Console.WriteLine("Error en InsertarHistorialCambioEnTransaccion: " + ex.Message);
                return false;
            }
        }

        public bool SepararDeportista_DuplicarDesempenosYEliminarOriginal(int idOriginal, List<Deportista> nuevos, int idUsuario)
        {
            if (idOriginal <= 0) return false;
            if (nuevos == null || nuevos.Count == 0) return false;

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1) Para cada nuevo deportista: insertar y luego duplicar los desempeños del original hacia el nuevo id
                        List<int> nuevosIds = new List<int>();
                        foreach (var nuevo in nuevos)
                        {
                            long nuevoId = 0;
                            string insertSql = @"INSERT INTO Deportistas (cedula, nombres, apellidos, genero, tipo_discapacidad)
                                     VALUES (@cedula, @nombres, @apellidos, @genero, @tipo_discapacidad);
                                     SELECT last_insert_rowid();";
                            using (var cmdIns = new SQLiteCommand(insertSql, conn, tran))
                            {
                                cmdIns.Parameters.AddWithValue("@cedula", (object)nuevo.cedula ?? DBNull.Value);
                                cmdIns.Parameters.AddWithValue("@nombres", (object)nuevo.nombres ?? DBNull.Value);
                                cmdIns.Parameters.AddWithValue("@apellidos", (object)nuevo.apellidos ?? DBNull.Value);
                                cmdIns.Parameters.AddWithValue("@genero", (object)nuevo.genero ?? DBNull.Value);
                                cmdIns.Parameters.AddWithValue("@tipo_discapacidad", (object)nuevo.tipo_discapacidad ?? DBNull.Value);

                                var res = cmdIns.ExecuteScalar();
                                nuevoId = (res == null) ? 0 : Convert.ToInt64(res);
                            }

                            if (nuevoId == 0) throw new Exception("No se pudo insertar uno de los deportistas nuevos.");

                            // Duplicar desempeños: insert SELECT copiando columnas excepto id_desempeno y reemplazando id_deportista por nuevoId
                            string dupSql = @"
                        INSERT INTO Desempeno (puntos, medalla, observaciones, tiempo, ubicacion, id_deportista, id_competencia, id_tecnico)
                        SELECT puntos, medalla, observaciones, tiempo, ubicacion, @nuevoId, id_competencia, id_tecnico
                        FROM Desempeno
                        WHERE id_deportista = @idOriginal;";
                            using (var cmdDup = new SQLiteCommand(dupSql, conn, tran))
                            {
                                cmdDup.Parameters.AddWithValue("@nuevoId", nuevoId);
                                cmdDup.Parameters.AddWithValue("@idOriginal", idOriginal);
                                cmdDup.ExecuteNonQuery();
                            }

                            nuevosIds.Add((int)nuevoId);

                            // Registrar en historial la creación del nuevo deportista usando la misma transacción/conexión
                            string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            bool okHist = InsertarHistorialCambioEnTransaccion(conn, tran, idUsuario, "Deportistas", (int)nuevoId, "RESULTANTE DE SEPARACION", fecha);
                            if (!okHist)
                            {
                                throw new Exception($"No se pudo insertar el historial para el deportista creado con id {nuevoId}.");
                            }
                        }

                        // 2) Eliminar todos los desempeños originales del deportista original
                        string delDesemSql = "DELETE FROM Desempeno WHERE id_deportista = @idOriginal;";
                        using (var cmdDelDes = new SQLiteCommand(delDesemSql, conn, tran))
                        {
                            cmdDelDes.Parameters.AddWithValue("@idOriginal", idOriginal);
                            cmdDelDes.ExecuteNonQuery();
                        }

                        // 3) Eliminar el deportista original
                        string delDepSql = "DELETE FROM Deportistas WHERE id_deportista = @idOriginal;";
                        using (var cmdDelDep = new SQLiteCommand(delDepSql, conn, tran))
                        {
                            cmdDelDep.Parameters.AddWithValue("@idOriginal", idOriginal);
                            cmdDelDep.ExecuteNonQuery();
                        }


                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        try { tran.Rollback(); } catch { }
                        Console.WriteLine("Error en SepararDeportista_DuplicarDesempenosYEliminarOriginal: " + ex.Message);
                        return false;
                    }
                }
            }
        }


        public Dictionary<int, List<string>> ObtenerDisciplinasPorTecnico(bool orderDesc = false)
        {
            var resultado = new Dictionary<int, List<string>>();

            using (var conn = GetConnection())
            {
                conn.Open();

                // Orden por id_tecnico (asc o desc) y luego por nombre_disciplina para consistencia al agregar.
                string orderDirection = orderDesc ? "DESC" : "ASC";

                string sql = $@"
            SELECT t.id_tecnico AS id_tecnico, di.nombre_disciplina AS nombre_disciplina
            FROM Tecnicos t
            LEFT JOIN Desempeno ds ON ds.id_tecnico = t.id_tecnico
            LEFT JOIN Competencias c ON c.id_competencia = ds.id_competencia
            LEFT JOIN Especialidades e ON e.id_especialidad = c.id_especialidad
            LEFT JOIN Disciplinas di ON di.id_disciplina = e.id_disciplina
            ORDER BY t.id_tecnico {orderDirection}, di.nombre_disciplina;
        ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // id_tecnico no debería ser null si existe la fila, pero chequeamos
                                if (reader.IsDBNull(0)) continue;
                                int id = Convert.ToInt32(reader["id_tecnico"]);
                                string disciplina = reader.IsDBNull(1) ? null : reader["nombre_disciplina"].ToString();

                                // Asegurar la clave existe (incluso si disciplina == null)
                                if (!resultado.ContainsKey(id))
                                    resultado[id] = new List<string>();

                                // Si hay disciplina válida, agregar sin duplicados
                                if (!string.IsNullOrWhiteSpace(disciplina) && !resultado[id].Contains(disciplina))
                                {
                                    resultado[id].Add(disciplina);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error en ObtenerDisciplinasPorTecnico: " + ex.Message);
                        // En caso de error devolvemos al menos el diccionario parcial (o vacío).
                    }
                }
            }

            return resultado;
        }


        public bool ActualizarTecnico(Tecnico tecnico)
        {
            string query = "UPDATE Tecnicos SET nombre_completo = @nombre_completo WHERE id_tecnico = @id_tecnico";
            int rowsAffected = 0;

            using (SQLiteConnection connection = GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_tecnico", tecnico.id_tecnico);
                    command.Parameters.AddWithValue("@nombre_completo", tecnico.nombre_completo);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al actualizar técnico: " + ex.Message);
                    }
                }
            }
            return rowsAffected > 0;
        }

        public bool FusionarTecnicosCrearNuevoYReasignar(List<int> idsViejos, Tecnico nuevoTecnico, int idUsuario)
        {
            if (idsViejos == null || idsViejos.Count < 2) return false;
            if (nuevoTecnico == null) return false;

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1) Insertar nuevo técnico
                        long nuevoId = 0;
                        string insertSql = "INSERT INTO Tecnicos (nombre_completo) VALUES (@nombre); SELECT last_insert_rowid();";
                        using (var cmdIns = new SQLiteCommand(insertSql, conn, tran))
                        {
                            cmdIns.Parameters.AddWithValue("@nombre", nuevoTecnico.nombre_completo ?? (object)DBNull.Value);
                            var res = cmdIns.ExecuteScalar();
                            nuevoId = res == null ? 0 : Convert.ToInt64(res);
                        }

                        if (nuevoId == 0) throw new Exception("No se pudo insertar el nuevo técnico.");

                        // 2) Reasignar desempeños: UPDATE Desempeno SET id_tecnico = nuevoId WHERE id_tecnico IN (...)
                        // Construir parámetros dinámicos para la lista IN
                        var idParams = new List<string>();
                        for (int i = 0; i < idsViejos.Count; i++)
                        {
                            idParams.Add($"@id{i}");
                        }
                        string inClause = string.Join(", ", idParams);
                        string updateSql = $"UPDATE Desempeno SET id_tecnico = @nuevoId WHERE id_tecnico IN ({inClause});";
                        using (var cmdUpd = new SQLiteCommand(updateSql, conn, tran))
                        {
                            cmdUpd.Parameters.AddWithValue("@nuevoId", nuevoId);
                            for (int i = 0; i < idsViejos.Count; i++)
                            {
                                cmdUpd.Parameters.AddWithValue(idParams[i], idsViejos[i]);
                            }
                            cmdUpd.ExecuteNonQuery();
                        }

                        // 3) Eliminar los técnicos viejos (usar la misma IN)
                        string deleteSql = $"DELETE FROM Tecnicos WHERE id_tecnico IN ({inClause});";
                        using (var cmdDel = new SQLiteCommand(deleteSql, conn, tran))
                        {
                            for (int i = 0; i < idsViejos.Count; i++)
                            {
                                cmdDel.Parameters.AddWithValue(idParams[i], idsViejos[i]);
                            }
                            cmdDel.ExecuteNonQuery();
                        }

                        // 4) Registrar en Historial_Cambios solo el técnico resultante (nuevoId)
                        string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        string histSql = "INSERT INTO Historial_Cambios (id_usuario, tabla_afectada, id_registro_afectado, accion, fecha_cambio) " +
                                         "VALUES (@idUsuario, @tabla, @idRegistro, @accion, @fecha);";
                        using (var cmdHist = new SQLiteCommand(histSql, conn, tran))
                        {
                            cmdHist.Parameters.AddWithValue("@idUsuario", idUsuario == 0 ? (object)DBNull.Value : idUsuario);
                            cmdHist.Parameters.AddWithValue("@tabla", "Tecnicos");
                            cmdHist.Parameters.AddWithValue("@idRegistro", (int)nuevoId);
                            cmdHist.Parameters.AddWithValue("@accion", "TECNICO FUSIONADO");
                            cmdHist.Parameters.AddWithValue("@fecha", fecha);
                            cmdHist.ExecuteNonQuery();
                        }

                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        try { tran.Rollback(); } catch { }
                        Console.WriteLine("Error en FusionarTecnicosCrearNuevoYReasignar: " + ex.Message);
                        return false;
                    }
                }
            }
        }



    }
}