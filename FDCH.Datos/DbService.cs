using FDCH.Entidades; // Importamos la capa de entidades
using System;
using System.Collections.Generic;
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

        // Consulta todos los registros del historial de cambios
        public List<HistorialCambio> ObtenerHistorialCambios()
        {
            var lista = new List<HistorialCambio>();
            using (var connection = GetConnection())
            {
                string query = "SELECT * FROM Historial_Cambios";
                using (var command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new HistorialCambio
                                {
                                    id_log = Convert.ToInt32(reader["id_log"]),
                                    id_usuario = Convert.ToInt32(reader["id_usuario"]),
                                    tabla_afectada = reader["tabla_afectada"].ToString(),
                                    id_registro_afectado = Convert.ToInt32(reader["id_registro_afectado"]),
                                    accion = reader["accion"].ToString(),
                                    fecha_cambio = Convert.ToDateTime(reader["fecha_cambio"])
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener historial de cambios: " + ex.Message);
                    }
                }
            }
            return lista;
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



    }
}